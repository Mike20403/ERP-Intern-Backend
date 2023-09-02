using DotNetStarter.Common;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Auth
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string? Username { get; set; }

        [Required]
        [RegularExpression(RegexPatterns.Password)]
        public string? Password { get; set; }
    }
}
