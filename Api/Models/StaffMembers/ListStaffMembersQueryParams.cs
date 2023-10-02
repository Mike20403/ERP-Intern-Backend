using Api.Models.Users;
using DotNetStarter.Common.Enums;

namespace Api.Models.StaffMembers
{
    public class ListStaffMembersQueryParams : ListUsersQueryParams
    {
        public StaffMemberType? Type { get; set; }
    }
}
