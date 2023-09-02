using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class Otp : BaseAuditingEntity
    {
        [Required]
        public OtpType Type { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public bool IsUsed { get; set; }

        [Required]
        public DateTime ExpiredDate { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public User User { get; set; }
    }
}
