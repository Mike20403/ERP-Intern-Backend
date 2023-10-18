using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using MediatR;

namespace DotNetStarter.Notifications.Invitations.AcceptInvitation
{
    public class UpdateOtpHandler : INotificationHandler<TalentAccepted>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public UpdateOtpHandler(IDotNetStarterUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(TalentAccepted notification, CancellationToken cancellationToken)
        {
            var code = await _unitOfWork.OtpRepository.FindAsync
            (
                filter: o => o.Code == notification.Code 
                        && o.Type == OtpType.InviteTalent 
                        && o.ExpiredDate >= DateTime.Now
                        && !o.IsUsed
            );
            code!.IsUsed = true;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
