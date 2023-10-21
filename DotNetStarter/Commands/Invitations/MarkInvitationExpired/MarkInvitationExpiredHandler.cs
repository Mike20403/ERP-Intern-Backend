using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;

namespace DotNetStarter.Commands.Invitations.MarkInvitationExpired
{
    public sealed class MarkInvitationExpiredHandler : BaseRequestHandler<MarkInvitationExpired>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public MarkInvitationExpiredHandler(IDotNetStarterUnitOfWork unitOfWork, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Process(MarkInvitationExpired request, CancellationToken cancellationToken)
        {
            var invitation = await _unitOfWork.InvitationRepository.FindAsync(filter: i => i.Id == request.InvitationId && i.InvitationStatus == InvitationStatus.Pending);

            if (invitation is not null)
            {
                invitation!.InvitationStatus = InvitationStatus.Expired;
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
