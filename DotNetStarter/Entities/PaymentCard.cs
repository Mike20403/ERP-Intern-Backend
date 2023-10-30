using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class PaymentCard
    {
        [Required]
        public Guid? PaymentId { get; set; }

        [Required]
        public Payment? Payment { get; set; }

        [Required]
        public Guid? CardId { get; set; }

        [Required]
        public Card? Card { get; set; }
    }
}
