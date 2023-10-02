using DotNetStarter.Common.Enums;

namespace Api.Dtos
{
    public class StaffMemberDto : UserDto
    {
        public StaffMemberType? Type { get; set; }
    }
}
