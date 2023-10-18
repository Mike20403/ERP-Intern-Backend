using DotNetStarter.Common.Enums;
using DotNetStarter.Common;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Users
{
    public class BaseUpsertUserRequest
    {
        [Required]
        public string? Firstname { get; set; }

        [Required]
        public string? Lastname { get; set; }

        [Required]
        [RegularExpression(RegexPatterns.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        //TODO: make required
        //[Required]
        public Gender? Gender { get; set; }
    }
}
