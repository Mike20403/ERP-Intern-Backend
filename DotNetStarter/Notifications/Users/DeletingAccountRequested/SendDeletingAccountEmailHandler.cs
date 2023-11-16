using DotNetStarter.Services.Email;
using MediatR;

namespace DotNetStarter.Notifications.Users.DeletingAccountRequested
{
    public sealed class DeletingAccountRequestedHandler : INotificationHandler<DeletingAccountRequested>
    {
        private readonly IEmailService _emailService;

        public DeletingAccountRequestedHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public async Task Handle(DeletingAccountRequested notification, CancellationToken cancellationToken)
        {
            string message = "Your account will permanently delete within 30 days";
            await _emailService.SendNotificationAsync(notification.Email, notification.Firstname, message);        
        }
    }
}
