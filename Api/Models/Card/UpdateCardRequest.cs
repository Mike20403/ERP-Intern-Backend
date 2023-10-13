using System.ComponentModel.DataAnnotations;

namespace Api.Models.Card
{
    public class UpdateCardRequest
    {
        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
