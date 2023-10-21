using DotNetStarter.Database.UnitOfWork;
using MediatR;

namespace DotNetStarter.Notifications.Invitations.TalentRegistered
{
    public sealed class UpdateInvitationHandler : INotificationHandler<TalentRegistered>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public UpdateInvitationHandler(IDotNetStarterUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(TalentRegistered notification, CancellationToken cancellationToken)
        {
            var invitation = await _unitOfWork.InvitationRepository.GetByIdAsync(notification.InvitationId);

            if (invitation is not null) { 
                invitation.TalentId = notification.TalentId;
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
