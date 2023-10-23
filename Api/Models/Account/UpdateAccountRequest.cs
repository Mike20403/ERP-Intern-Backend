using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Account
{
    public class UpdateAccountRequest
    {
        [Required]
        public string? Firstname { get; set; }

        [Required]
        public string? Lastname { get; set; }

        [Required]
        [RegularExpression(RegexPatterns.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required]
        public Gender? Gender { get; set; }
    }
}
