using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Email;

namespace DotNetStarter.Commands.Auth.ForgotPassword
{
    public sealed class ForgotPasswordHandler : BaseRequestHandler<ForgotPassword>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IEmailService _emailService;

        public ForgotPasswordHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IEmailService emailService) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
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
                ExpiredDate = DateTime.Now.AddHours(1),
            };

            await _unitOfWork.OtpRepository.CreateAsync(otp);
            await _unitOfWork.SaveChangesAsync();

            await _emailService.SendResetPasswordEmailAsync(user.Username, user.Firstname, otp.Code);
        }
    }
}
