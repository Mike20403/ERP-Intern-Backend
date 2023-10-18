using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class Talent : User
    {
        [Required]
        public bool IsAvailable { get; set; }
    }
}
