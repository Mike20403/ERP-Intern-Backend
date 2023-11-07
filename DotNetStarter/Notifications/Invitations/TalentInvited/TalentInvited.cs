using MediatR;

namespace DotNetStarter.Notifications.Invitations.TalentInvited
{
    public sealed class TalentInvited : INotification
    {
        public string Email { get; }

        public string ProjectName { get; }

        public Guid ProjectId { get; }

        public string InviterName { get; }

        public bool IsExists { get; }

        public string? Code { get; }

        public Guid InvitationId { get; }

        public TalentInvited(
            string email, 
            Guid invitationId,
            string projectName, 
            Guid projectId,
            string inviterName,
            bool isExists, 
            string? code = null
        )
        {
            Email = email;
            InvitationId = invitationId;
            ProjectName = projectName;
            ProjectId = projectId;
            InviterName = inviterName;
            IsExists = isExists;
            Code = code;
        }   
    }
}
