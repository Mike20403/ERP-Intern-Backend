using System.ComponentModel.DataAnnotations;

namespace Api.Models.Invitations
{
    public class ProccessInvitationRequest
    {
        [Required]
        public bool? IsAccepted { get; set; }
    }
}
