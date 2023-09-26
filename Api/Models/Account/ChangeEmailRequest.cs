using System.ComponentModel.DataAnnotations;

namespace Api.Models.Account
{
    public class ChangeEmailRequest
    {
        [Required]
        [EmailAddress]
        public string? NewEmail { get; set; }
    }
}
