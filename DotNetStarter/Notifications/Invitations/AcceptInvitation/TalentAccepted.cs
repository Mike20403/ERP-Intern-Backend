using MediatR;

namespace DotNetStarter.Notifications.Invitations.AcceptInvitation
{
    public class TalentAccepted : INotification
    {
        public Guid? InvitationId { get; }

        public Guid? TalentId { get; }

        public string? Email { get; }

        public string? Code { get; }

        public TalentAccepted(Guid? invitationId, Guid? talentId, string? email, string? code)
        {
            InvitationId = invitationId;
            Email = email;
            Code = code;
            TalentId = talentId;
        }
    }
}
