using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class MovingCardDto
    {
        [Required]
        public Guid Id { get; set; }

        public Guid? PrevCardId { get; set; }

        public Guid? NextCardId { get; set; }

        [Required]
        public Guid StageId { get; set; }
    }
}
