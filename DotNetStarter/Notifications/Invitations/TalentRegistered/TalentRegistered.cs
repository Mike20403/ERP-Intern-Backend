using MediatR;

namespace DotNetStarter.Notifications.Invitations.TalentRegistered
{
    public sealed class TalentRegistered : INotification
    {
        public Guid InvitationId { get; }

        public Guid TalentId { get; }

        public TalentRegistered(Guid invitationId, Guid talentId)
        {
            InvitationId = invitationId;
            TalentId = talentId;
        }
    }
}
