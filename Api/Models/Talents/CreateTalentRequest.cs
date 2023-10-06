using Api.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Talents
{
    public class CreateTalentRequest : CreateUserRequest
    {
        [Required]
        public bool? IsAvailable {get; set;}
    }
}
