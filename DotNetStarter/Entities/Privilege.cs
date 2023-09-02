using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class Privilege : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public List<Role> Roles { get; set; }

        public List<User> Users { get; set; }
    }
}
