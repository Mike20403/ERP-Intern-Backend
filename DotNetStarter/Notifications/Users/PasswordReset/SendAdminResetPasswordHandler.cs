using DotNetStarter.Services.Email;
using MediatR;

namespace DotNetStarter.Notifications.Users.ResetPasswordByAdminRequested
{
    public sealed class SendAdminResetPasswordHandler : INotificationHandler<PasswordReset>
    {
        private readonly IEmailService _emailService;

        public SendAdminResetPasswordHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public async Task Handle(PasswordReset notification, CancellationToken cancellationToken)
        {
            await _emailService.SendAdminResetPasswordEmailAsync(notification.Username, notification.Firstname, notification.Password);
        }
    }
}
