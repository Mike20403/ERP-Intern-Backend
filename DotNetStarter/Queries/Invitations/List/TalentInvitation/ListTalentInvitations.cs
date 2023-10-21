using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Invitations.List.TalentInvitation
{
    public sealed class ListTalentInvitations : ListRequest<Invitation>
    {
        public Guid TalentId { get; set; }

        public InvitationStatus? InvitationStatus { get; set; }

        public ListTalentInvitations
        (
            Guid talentId,
            InvitationStatus? invitationStatus,
            int pageNumber,
            int pageSize,
            string? searchQuery,
            string? orderBy
        ) : base(pageNumber, pageSize, searchQuery, orderBy)
        {
            TalentId = talentId;
            InvitationStatus = invitationStatus;
        }
    }
}
