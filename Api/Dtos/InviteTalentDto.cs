using Api.Common;

namespace Api.Dtos
{
    public class InviteTalentDto
    {
        [RequiredIfNull(nameof(Email))]
        public Guid? Id { get; set; }

        [RequiredIfNull(nameof(Id))]
        public string? Email { get; set; }
    }
}
