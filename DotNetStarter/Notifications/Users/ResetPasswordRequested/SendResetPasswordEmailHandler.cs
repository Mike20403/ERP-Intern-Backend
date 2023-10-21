using DotNetStarter.Services.Email;
using MediatR;

namespace DotNetStarter.Notifications.Users.ResetPasswordRequested
{
    public sealed class SendResetPasswordEmailHandler : INotificationHandler<ResetPasswordRequested>
    {
        private readonly IEmailService _emailService;

        public SendResetPasswordEmailHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(ResetPasswordRequested notification, CancellationToken cancellationToken)
        {
            await _emailService.SendResetPasswordEmailAsync(notification.Username, notification.Firstname, notification.Code);
        }
    }
}
