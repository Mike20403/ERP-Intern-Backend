using DotNetStarter.Common.Enums;

namespace DotNetStarter.Common.Models
{
    public class ImportStaffMemberDto
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? PhoneNumber { get; set; }

        public Gender? Gender { get; set; }

        public Status? Status { get; set; }
        
        public string? Username { get; set; }

        public string? Password { get; set; }

        public StaffMemberType? RoleName { get; set; }

        public string? Privileges { get; set; }
    }
}
