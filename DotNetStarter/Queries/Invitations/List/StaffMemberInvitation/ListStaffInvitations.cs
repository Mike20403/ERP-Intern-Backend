using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Invitations.List.StaffMemberInvitation
{
    public sealed class ListStaffInvitations : ListRequest<Invitation>
    {
        public Guid StaffMemberId { get; }

        public string StaffMemberRole { get; }

        public Guid? ProjectId { get; }

        public bool? IsTalentExisted { get; }

        public InvitationStatus? InvitationStatus { get; }

        public ListStaffInvitations
        (
            Guid staffMemberId,
            string staffMemberRole,
            Guid? projectId,
            bool? isTalentExisted,
            InvitationStatus? invitationStatus,
            int pageNumber,
            int pageSize,
            string? searchQuery,
            string? orderBy
        ) : base(pageNumber, pageSize, searchQuery, orderBy)
        {
            IsTalentExisted = isTalentExisted;
            StaffMemberId = staffMemberId;
            StaffMemberRole = staffMemberRole;
            InvitationStatus = invitationStatus;
            ProjectId = projectId;
        }
    }
}
