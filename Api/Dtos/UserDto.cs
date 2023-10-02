using DotNetStarter.Common.Enums;

namespace Api.Dtos
{
    public class UserDto
    {
        public Guid? Id { get; set; }

        public string? Username { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? PhoneNumber { get; set; }

        public Gender? Gender { get; set; }

        public Status? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
