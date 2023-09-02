using System.ComponentModel.DataAnnotations;

namespace Api.Models.Auth
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string? Username { get; set; }
    }
}
