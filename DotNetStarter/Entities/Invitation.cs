using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class Invitation : BaseAuditingEntity
    {
        [Required]
        public Guid? ProjectId { get; set; }

        [Required]
        public Project? Project { get; set; }

        public Guid? TalentId { get; set; }

        public Talent? Talent { get; set; }

        [Required]
        public Guid? InviterId { get; set; }

        [Required]
        public User? Inviter { get; set; }

        [Required]
        public InvitationStatus? InvitationStatus { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
    }
}
