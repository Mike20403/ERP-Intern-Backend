using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Email;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DotNetStarter.Notifications.Users.UserCreated
{
    public sealed class SendUserCreatedEmailHandler : INotificationHandler<UserCreated>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IEmailService _emailService;

        private readonly IConfiguration _configuration;

        public SendUserCreatedEmailHandler(
            IDotNetStarterUnitOfWork unitOfWork,
            IEmailService emailService,
            IConfiguration configuration
        )
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _configuration = configuration;
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
                    ExpiredDate = DateTime.Now.AddMinutes(int.Parse(_configuration["Otp:ActiveOtpLifetimeDuration"]!)),
                };
                await _unitOfWork.OtpRepository.CreateAsync(activeOtp);
                await _unitOfWork.SaveChangesAsync();

                await _emailService.SendActivateAccountAsync(notification.Username, notification.Firstname, activeOtp.Code);
            }
        }
    }
}
