using Api.Models.Users;
using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.StaffMembers
{
    public class UpdateStaffMemberRequest : UpdateUserRequest
    {
        [Required]
        public StaffMemberType? Type { get; set; }
    }
}
