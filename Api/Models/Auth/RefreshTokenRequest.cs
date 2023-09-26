using System.ComponentModel.DataAnnotations;

namespace Api.Models.Auth
{
    public class RefreshTokenRequest
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid TokenId { get; set; }

        [Required]
        public string Secret { get; set; }
    }
}