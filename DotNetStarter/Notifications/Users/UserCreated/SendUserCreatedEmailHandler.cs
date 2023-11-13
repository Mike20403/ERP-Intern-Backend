using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Configuration;
using DotNetStarter.Services.Email;
using MediatR;
using Microsoft.Extensions.Options;

namespace DotNetStarter.Notifications.Users.UserCreated
{
    public sealed class SendUserCreatedEmailHandler : INotificationHandler<UserCreated>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IEmailService _emailService;

        private readonly AppSettings _appSettings;

        public SendUserCreatedEmailHandler(
            IDotNetStarterUnitOfWork unitOfWork,
            IEmailService emailService,
            IOptions<AppSettings> appSettings
        )
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _appSettings = appSettings.Value;
        }

        public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {
            if (notification.Status == Status.Active)
            {
                string message = "Your account is created successfully!";
                await _emailService.SendNotificationAsync(notification.Username, notification.Firstname, message);
            }
            else if (notification.Status == Status.Inactive)
            {
                var activeOtp = new Otp
                {
                    UserId = notification.UserId,
                    Type = OtpType.ActivateAccount,
                    Code = new Random().Next(0, 1000000).ToString("D6"),
                    IsUsed = false,
                    ExpiredDate = DateTime.Now.AddMinutes(_appSettings.Otp.ActiveOtpLifetimeDuration!),
                };
                await _unitOfWork.OtpRepository.CreateAsync(activeOtp);
                await _unitOfWork.SaveChangesAsync();

                await _emailService.SendActivateAccountAsync(notification.Username, notification.Firstname, activeOtp.Code);
            }
        }
    }
}
