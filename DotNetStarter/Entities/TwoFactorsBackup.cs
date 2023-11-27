using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class TwoFactorsBackup : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public User? User { get; set; }

        [Required]
        public string? Code { get; set; }

        [Required]
        public bool IsUsed { get; set; }
    }
}