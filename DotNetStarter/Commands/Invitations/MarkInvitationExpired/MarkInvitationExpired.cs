using MediatR;

namespace DotNetStarter.Commands.Invitations.MarkInvitationExpired
{
    public sealed class MarkInvitationExpired : IRequest
    {
        public Guid InvitationId { get; set; }

        public MarkInvitationExpired(Guid invitationId)
        {
            InvitationId = invitationId;
        }
    }
}
