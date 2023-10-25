using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Invitations.InviteTalents
{
    public sealed class InviteTalents : IRequest<List<Invitation>>
    {
        public Guid ProjectId { get; }

        public Guid InviterId { get; }

        public string InviterRole { get; }

        public List<InviteTalent> Talents { get; }

        public InviteTalents(Guid projectId, Guid inviterId, string inviterRole, List<InviteTalent> talents) { 
            ProjectId = projectId;
            InviterId = inviterId;
            InviterRole = inviterRole;
            Talents = talents;
        }
    }
}
