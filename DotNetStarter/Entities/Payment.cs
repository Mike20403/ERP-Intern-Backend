using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class Payment : BaseAuditingEntity
    {
        [Required]
        public PaymentStatus PaymentStatus { get; set; }

        public string? Description { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public Project? Project { get; set; }

        [Required]
        public Guid TalentId { get; set; }

        [Required]
        public Talent? Talent { get; set; }

        [Required]
        public double Amount { get; set; }

        public List<Card>? Cards { get; set; }
    }
}
