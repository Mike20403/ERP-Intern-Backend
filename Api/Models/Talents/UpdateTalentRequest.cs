using Api.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Talents
{
    public class UpdateTalentRequest : UpdateUserRequest
    {
        [Required]
        public bool? IsAvailable { get; set; }
    }
}
