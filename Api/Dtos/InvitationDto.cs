using DotNetStarter.Common.Enums;
using SendGrid.Helpers.Mail;

namespace Api.Dtos
{
    public class InvitationDto
    {
        public Guid? Id { get; set; }

        public Guid? ProjectId { get; set; } 

        public Guid? TalentId { get; set; }

        public Guid? InviterId { get; set; }

        public InvitationStatus? InvitationStatus { get; set; }

        public string? EmailAddress { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
