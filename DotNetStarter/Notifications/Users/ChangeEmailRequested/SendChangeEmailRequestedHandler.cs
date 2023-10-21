using DotNetStarter.Services.Email;
using MediatR;

namespace DotNetStarter.Notifications.Users.ChangeEmailRequested
{
    public sealed class SendChangeEmailRequestedHandler : INotificationHandler<ChangeEmailRequested>
    {
        private readonly IEmailService _emailService;

        public SendChangeEmailRequestedHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(ChangeEmailRequested notification, CancellationToken cancellationToken)
        {
            await _emailService.SendChangeEmailRequestAsync(notification.Email, notification.NewEmail, notification.Firstname, notification.Code);
        }
    }
}
