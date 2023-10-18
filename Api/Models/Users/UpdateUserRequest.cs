using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Users
{
    public class UpdateUserRequest : BaseUpsertUserRequest
    {
        [Required]
        public Status? Status { get; set; }
    }
}
