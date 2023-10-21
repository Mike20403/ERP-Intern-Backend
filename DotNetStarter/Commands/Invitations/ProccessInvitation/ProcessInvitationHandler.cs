using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Invitations.ProcessInvitation
{
    public sealed class ProcessInvitationHandler : BaseRequestHandler<ProcessInvitation>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ProcessInvitationHandler(
            IDotNetStarterUnitOfWork unitOfWork,
            IServiceProvider serviceProvider

        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Process(ProcessInvitation request, CancellationToken cancellationToken)
        {
            var invitation = await _unitOfWork.InvitationRepository.GetByIdAsync(request.InvitationId);

            invitation!.InvitationStatus = request.IsAccepted ? InvitationStatus.Accepted : InvitationStatus.Rejected;

            if (invitation.InvitationStatus is InvitationStatus.Accepted)
            {
                var project = await _unitOfWork.ProjectRepository.FindAsync(ClassUtils.GetPropertyName<Project>(t => t.Talents), p => p.Id == request.ProjectId);
                var talent = await _unitOfWork.TalentRepository.FindAsync(ClassUtils.GetPropertyName<Talent>(p => p.Projects), t => t.Id == request.TalentId);

                project!.Talents!.Add(talent!);
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
