using Api.Common;
using DotNetStarter.Common;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Account
{
    public class ChangePasswordRequest
    {
        [Required]
        [RegularExpression(RegexPatterns.Password)]
        public string CurrentPassword { get; set; }

        [Required]
        [RegularExpression(RegexPatterns.Password)]
        [NotEqual(nameof(CurrentPassword), ErrorMessage = "New password must be different from the current password.")]
        public string NewPassword { get; set; }
    }
}
