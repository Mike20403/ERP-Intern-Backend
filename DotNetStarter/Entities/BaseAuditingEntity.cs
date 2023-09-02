using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class BaseAuditingEntity : BaseEntity
    {
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public string UpdatedBy { get; set; }
    }
}
