using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Otps
{
    public class ResendOtpRequest
    {
        [Required]
        public OtpType? Type { get; set; }

        [Required]
        public string? Code { get; set; }
    }
}
