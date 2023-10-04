namespace DotNetStarter.Common
{
    public static class DomainConstraints
    {
        public const string XPagination = "X-Pagination";
        public static readonly List<string> StaffMemberRoleNames = new List<string>
        {
            RoleNames.AgencyMember,
            RoleNames.ProjectManager,
        };
    }
}
