using DotNetStarter.Common;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Users
{
    public class CreateUserRequest : UpdateUserRequest
    {
        [Required]
        [EmailAddress]
        public string? Username { get; set; }

        [Required]
        [RegularExpression(RegexPatterns.Password)]
        public string? Password { get; set; }
    }
}
