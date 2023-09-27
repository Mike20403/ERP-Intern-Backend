using System.ComponentModel.DataAnnotations;

namespace Api.Models.Account
{
    public class ConfirmChangeEmailRequest
    {
        [Required]
        [EmailAddress]
        public string? CurrentEmail { get; set; }

        [Required]
        [EmailAddress]
        public string? NewEmail { get; set; }

        [Required]
        public string? ActiveCode { get; set; }
    }
}
