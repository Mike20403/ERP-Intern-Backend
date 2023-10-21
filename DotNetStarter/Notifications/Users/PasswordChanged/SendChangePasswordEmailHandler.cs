using DotNetStarter.Services.Email;
using MediatR;

namespace DotNetStarter.Notifications.Users.PasswordChanged
{
    public sealed class SendChangePasswordEmailHandler : INotificationHandler<PasswordChanged>
    {
        private readonly IEmailService _emailService;

        public SendChangePasswordEmailHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(PasswordChanged notification, CancellationToken cancellationToken)
        {
            await _emailService.SendChangePasswordEmailAsync(notification.Username, notification.Firstname, notification.Lastname);
        }
    }
}
