using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class User : BaseAuditingEntity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }

        public Gender? Gender { get; set; }

        [Required]
        public Status? Status { get; set; }

        [Required]
        public Guid? RoleId { get; set; }

        [Required]
        public Role? Role { get; set; }

        public List<Privilege> Privileges { get; set; }
    }
}
