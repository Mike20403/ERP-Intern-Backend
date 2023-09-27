using System.ComponentModel.DataAnnotations;

namespace Api.Models.Account
{
    public class ActivateEmailRequest
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? ActiveCode { get; set; }
    }
}
