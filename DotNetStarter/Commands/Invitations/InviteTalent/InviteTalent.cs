using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Invitations.InviteTalent
{
    public class InviteTalent : IRequest<Invitation>
    {
        public string? Email { get; }

        public Guid ProjectId { get; }

        public Guid InviterId { get; }

        public string InviterRole { get; }

        public Guid? TalentId { get; }

        public InviteTalent(string? email, Guid projectId, Guid inviterId, string inviterRole,Guid? talentId) { 
            Email = email;
            ProjectId = projectId;
            InviterId = inviterId;
            InviterRole = inviterRole;
            TalentId = talentId;
        }
    }
}
