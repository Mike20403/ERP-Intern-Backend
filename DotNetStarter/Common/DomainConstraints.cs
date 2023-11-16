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
        public static readonly string[] AllowedExtensions = { "jpg", "jpeg", "png", "pdf", "txt" };
        public static readonly string[] AllowedContentTypes = { "image/jpeg", "image/png", "application/pdf", "text/plain" };

        public const string TokenType = "type";
        public const string CanChangePasswordPolicy = "CanChangePassword";
        public const string CanRecoverAccountPolicy = "CanRecoverAccount";
    }
}
