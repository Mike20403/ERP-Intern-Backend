using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Email;
using EllipticCurve;
using Microsoft.Extensions.Configuration;

namespace DotNetStarter.Commands.Auth.ForgotPassword
{
    public sealed class ForgotPasswordHandler : BaseRequestHandler<ForgotPassword>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IEmailService _emailService;

        private readonly IConfiguration _configuration;

        public ForgotPasswordHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IEmailService emailService, IConfiguration configuration) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _configuration = configuration;
        }

        public override async Task Process(ForgotPassword request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindAsync(filter: u => u.Username == request.Username);
            var otp = new Otp
            {
                UserId = user!.Id,
                Type = OtpType.ResetPassword,
                Code = new Random().Next(0, 1000000).ToString("D6"),
                IsUsed = false,
                ExpiredDate = DateTime.Now.AddMinutes(int.Parse(_configuration["Otp:ActiveOtpLifetimeDuration"]!)),
            };

            await _unitOfWork.OtpRepository.CreateAsync(otp);
            await _unitOfWork.SaveChangesAsync();

            await _emailService.SendResetPasswordEmailAsync(user.Username, user.Firstname, otp.Code);
        }
    }
}
