using DotNetStarter.Services.Email;
using MediatR;

namespace DotNetStarter.Notifications.Users.SentOtp
{
    public sealed class OtpRenewedHandler : INotificationHandler<OtpRenewed>
    {
        private readonly IEmailService _emailService;

        public OtpRenewedHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(OtpRenewed notification, CancellationToken cancellationToken)
        {
            await _emailService.ResendOtp(notification.Email, notification.Firstname, notification.Code);
        }
    }
}
