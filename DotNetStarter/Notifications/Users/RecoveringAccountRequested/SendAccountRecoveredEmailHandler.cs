using DotNetStarter.Services.Email;
using MediatR;

namespace DotNetStarter.Notifications.Users.RecoveringAccountRequested
{
    public sealed class SendAccountRecoveredEmailHandler : INotificationHandler<RecoveringAccountRequested>
    {
        private readonly IEmailService _emailService;

        public SendAccountRecoveredEmailHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(RecoveringAccountRequested notification, CancellationToken cancellationToken)
        {
            await _emailService.SendRecoverAccountEmailAsync(notification.Email, notification.Firstname, notification.Code);
        }
    }
}
