using System.ComponentModel.DataAnnotations;

namespace Api.Models.Card
{
    public class CreateCardRequest
    {
        [Required]
        public string? Name { get; set; }

        public Guid? PrevCardId { get; set; }

        public Guid? NextCardId { get; set; }

        [Required]
        public Guid StageId { get; set; }
    }
}
