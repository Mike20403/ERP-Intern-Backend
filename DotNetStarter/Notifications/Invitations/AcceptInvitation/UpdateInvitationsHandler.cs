using DotNetStarter.Database.UnitOfWork;
using MediatR;

namespace DotNetStarter.Notifications.Invitations.AcceptInvitation
{
    public class UpdateInvitationsHandler : INotificationHandler<TalentAccepted>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        public UpdateInvitationsHandler(IDotNetStarterUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(TalentAccepted notification, CancellationToken cancellationToken)
        {
            var invitation = await _unitOfWork.InvitationRepository.GetByIdAsync(notification.InvitationId!.Value);

            if (invitation != null) { 
                invitation.TalentId = notification.TalentId;
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
