using DotNetStarter.Services.Email;
using MediatR;

namespace DotNetStarter.Notifications.Users.EmailChanged
{
    public sealed class SendEmailChangedEmailHandler : INotificationHandler<EmailChanged>
    {
        private readonly IEmailService _emailService;

        public SendEmailChangedEmailHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(EmailChanged notification, CancellationToken cancellationToken)
        {
            // Send notification to old email - Send active code to new email
            string message = "Congratulation! you have changed your email, this email will no longer available";
            await _emailService.SendNotificationAsync(notification.OldEmail, notification.Firstname, message);
            await _emailService.SendActivateAccountAsync(notification.Email, notification.Firstname, notification.Code);
        }
    }
}
