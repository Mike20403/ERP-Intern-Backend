using Api.Models.Users;
using DotNetStarter.Common;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Invitations
{
    public class RegisterTalentRequest : BaseUpsertUserRequest
    {
        [Required]
        public Guid? InvitationId { get; set; }

        [Required]
        public string? Code { get; set; }

        [Required]
        [EmailAddress]
        public string? Username { get; set; }

        [Required]
        [RegularExpression(RegexPatterns.Password)]
        public string? Password { get; set; }
    }
}
