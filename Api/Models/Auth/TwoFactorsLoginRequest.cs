using System.ComponentModel.DataAnnotations;

namespace Api.Models.Auth
{
    public class TwoFactorsLoginRequest
    {
        [Required]
        public string? TwoFactorsCode { get; set; }
    }
}
