using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class Role : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public List<Privilege> Privileges { get; set; }
    }
}
