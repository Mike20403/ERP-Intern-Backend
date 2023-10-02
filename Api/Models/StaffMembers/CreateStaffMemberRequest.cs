using Api.Models.Users;
using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.StaffMembers
{
    public class CreateStaffMemberRequest : CreateUserRequest
    {
        [Required]
        public StaffMemberType? Type { get; set; }
    }
}
