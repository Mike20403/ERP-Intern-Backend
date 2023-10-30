using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetStarter.Entities
{
    public class Card : BaseAuditingEntity
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public Guid? PrevCardId { get; set; }

        [ForeignKey(nameof(PrevCardId))]
        public Card? PrevCard { get; set; }

        public Guid? NextCardId { get; set; }

        [ForeignKey(nameof(NextCardId))]
        public Card? NextCard { get; set; }

        [Required]
        public Guid StageId { get; set; }

        [Required]
        public Stage? Stage { get; set; }

        public List<Attachment>? Attachments { get; set; }

        public List<Talent>? Owners { get; set; }

        public List<Payment>? Payments { get; set; }
    }
}
