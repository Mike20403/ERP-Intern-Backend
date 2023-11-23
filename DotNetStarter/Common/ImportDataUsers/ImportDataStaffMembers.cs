using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Common.ImportDataUsers
{
    public class ImportDataStaffMembers
    {
        [Required]
        public string? Firstname { get; set; }

        [Required]
        public string? Lastname { get; set; }

        [Required]
        [RegularExpression(RegexPatterns.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required]
        public Gender? Gender { get; set; }

        [Required]
        public Status? Status { get; set; }

        [Required]
        [EmailAddress]
        public string? Username { get; set; }

        [Required]
        [RegularExpression(RegexPatterns.Password)]
        public string? Password { get; set; }

        [Required]
        public StaffMemberType? RoleName { get; set; }

        public List<string>? Privileges { get; set; }
    }
}
