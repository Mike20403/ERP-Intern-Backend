using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class AuthToken : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [Required]
        public Guid TokenId { get; set; }

        [Required]
        public string Secret { get; set; }

        [Required]
        public bool IsUsed { get; set; }

        [Required]
        public DateTime ExpiredDate { get; set; }
    }
}