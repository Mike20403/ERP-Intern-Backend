using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class RolePrivilege : BaseEntity
    {
        [Required]
        public Guid? RoleId { get; set; }

        [Required]
        public Role? Role { get; set; }

        [Required]
        public Guid? PrivilegeId { get; set; }

        [Required]
        public Privilege? Privilege { get; set; }
    }
}
