using MediatR;

namespace DotNetStarter.Commands.Invitations.ProcessInvitation
{
    public class ProcessInvitation : IRequest
    {
        public Guid ProjectId { get; }

        public Guid TalentId { get; }

        public Guid InvitationId { get; }

        public bool IsAccepted { get; }

        public ProcessInvitation(Guid projectId, Guid invitationId, Guid talentId, bool isAccepted)
        {
            ProjectId = projectId;
            InvitationId = invitationId;
            TalentId = talentId;
            IsAccepted = isAccepted;
        }
    }
}
