using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class Stage : BaseAuditingEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public Guid? ProjectId { get; set; }

        [Required]
        public Project? Project { get; set; }

        public bool IsNotificationEnabled { get; set; } 

        public List<Card>? Cards { get; set; }
    }
}
