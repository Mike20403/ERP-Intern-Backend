using DotNetStarter.Common;
using DotNetStarter.Common.Enums;

namespace DotNetStarter.Extensions
{
    public static class EnumExtensions
    {
        public static string ToRoleName(this StaffMemberType @this) => @this switch
        {
            StaffMemberType.AgencyMember => RoleNames.AgencyMember,
            StaffMemberType.ProjectManager => RoleNames.ProjectManager,
            _ => throw new NotSupportedException(),
        };

        public static List<string> ToRoleNames(this StaffMemberType? @this) => @this switch
        {
            StaffMemberType.AgencyMember => new List<string> { @this!.Value.ToRoleName() },
            StaffMemberType.ProjectManager => new List<string> { @this!.Value.ToRoleName() },
            _ => new List<string> { RoleNames.AgencyMember, RoleNames.ProjectManager },
        };

        public static StaffMemberType ToStaffMemberType(this string @this) => @this switch
        {
            RoleNames.AgencyMember => StaffMemberType.AgencyMember,
            RoleNames.ProjectManager => StaffMemberType.ProjectManager,
            _ => throw new NotSupportedException(),
        };
    }
}
