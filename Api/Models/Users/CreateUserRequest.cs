using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Users
{
    public class CreateUserRequest
    {
        [Required]
        [EmailAddress]
        public string? Username { get; set; }

        [Required]
        public string? Firstname { get; set; }

        [Required]
        public string? Lastname { get; set; }

        [Required]
        [RegularExpression(RegexPatterns.Password)]
        public string? Password { get; set; }

        [Required]
        [RegularExpression(RegexPatterns.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required]
        public Status? Status { get; set; }
    }
}
