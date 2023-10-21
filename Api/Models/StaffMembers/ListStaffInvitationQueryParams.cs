using Api.Models.Invitations;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.StaffMembers
{
    public class ListStaffInvitationQueryParams : ListInvitationsQueryParams
    {
        public bool? IsTalentExisted { get; set; }
    }
}
