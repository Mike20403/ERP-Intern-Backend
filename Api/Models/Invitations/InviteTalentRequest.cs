using Api.Common;

namespace Api.Models.Invitations
{
    public class InviteTalentRequest
    {
        [RequiredIfNull(nameof(Email))]
        public Guid? TalentId { get; set; }

        [RequiredIfNull(nameof(TalentId))]
        public string? Email { get; set;}
    }
}
