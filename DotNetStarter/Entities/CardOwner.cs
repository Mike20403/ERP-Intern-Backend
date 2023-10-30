using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetStarter.Entities
{
    public class CardOwner
    {
        [Required]
        public Guid? CardId { get; set; }

        [ForeignKey(nameof(CardId))]
        [Required]
        public Card? Card { get; set; }

        [Required]
        public Guid? OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        [Required]
        public Talent? Owner { get; set; }
    }
}