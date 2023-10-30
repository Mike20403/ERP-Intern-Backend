using System.ComponentModel.DataAnnotations;

namespace Api.Models.Payments
{
    public class UpsertPaymentRequest
    {
        public string? Description { get; set; }

        [Required]
        public List<Guid>? CardIds { get; set; }

        public double? Amount { get; set;}
    }
}
