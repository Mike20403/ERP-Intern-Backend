using DotNetStarter.Common.Enums;

namespace Api.Dtos
{
    public class AccountDto
    {
        public Guid? Id { get; set; }

        public string? Username { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? PhoneNumber { get; set; }

        public Gender? Gender { get; set; }
    }
}
