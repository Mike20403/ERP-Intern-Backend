using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class UserPrivilege : BaseEntity
    {
        [Required]
        public Guid? UserId { get; set; }

        [Required]
        public User? User { get; set; }

        [Required]
        public Guid? PrivilegeId { get; set; }

        [Required]
        public Privilege? Privilege { get; set; }
    }
}
