using System.ComponentModel.DataAnnotations;

namespace Api.Models.Payments
{
    public class ProcessPaymentRequest
    {
        [Required]
        public bool? IsAccepted { get; set; }
    }
}
