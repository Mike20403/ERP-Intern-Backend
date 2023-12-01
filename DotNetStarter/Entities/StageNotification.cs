using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class StageNotification
    {
        [Required]
        public Guid? StageId { get; set; }

        [Required]
        public Stage? Stage { get; set; }

        [Required]
        public Guid? UserId { get; set; }

        [Required]
        public User? User { get; set; }
    }
}
