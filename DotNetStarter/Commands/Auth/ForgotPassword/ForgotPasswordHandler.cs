using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.ResetPasswordRequested;
using DotNetStarter.Services.Configuration;
using Microsoft.Extensions.Options;

namespace DotNetStarter.Commands.Auth.ForgotPassword
{
    public sealed class ForgotPasswordHandler : BaseRequestHandler<ForgotPassword>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly AppSettings _appSettings;

        public ForgotPasswordHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IOptions<AppSettings> appSettings) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
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
                ExpiredDate = DateTime.Now.AddMinutes(_appSettings.Otp.ActiveOtpLifetimeDuration!),
            };

            await _unitOfWork.OtpRepository.CreateAsync(otp);
            await _unitOfWork.SaveChangesAsync();

            new ResetPasswordRequested(user.Username, user.Firstname, otp.Code).Enqueue();
        }
    }
}
