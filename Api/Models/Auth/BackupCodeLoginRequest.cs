using System.ComponentModel.DataAnnotations;

namespace Api.Models.Auth
{
    public class BackupCodeLoginRequest
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? BackupCode { get; set; }
    }
}
