using DotNetStarter.Common.Enums;

namespace DotNetStarter.Common.Models
{
    public class ImportTalentDto
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? PhoneNumber { get; set; }

        public Gender? Gender { get; set; }

        public Status? Status { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool? IsAvailable { get; set; }

        public string? Privileges { get; set; }
    }
}
