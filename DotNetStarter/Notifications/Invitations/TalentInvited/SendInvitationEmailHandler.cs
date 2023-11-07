using DotNetStarter.Services.Email;
using MediatR;

namespace DotNetStarter.Notifications.Invitations.TalentInvited
{
    public sealed class SendInvitationEmailHandler : INotificationHandler<TalentInvited>
    {
        private readonly IEmailService _emailService;

        public SendInvitationEmailHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(TalentInvited notification, CancellationToken cancellationToken)
        {
            await _emailService.SendInvitationEmailAsync(
                notification.Email,
                notification.InvitationId,
                notification.ProjectName,
                notification.ProjectId,
                notification.InviterName,
                notification.IsExists,
                notification.Code
            );
        }
    }
}
