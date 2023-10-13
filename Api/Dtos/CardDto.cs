using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class CardDto
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string Description { get; set; }

        public Guid? PrevCardId { get; set; }

        public Guid? NextCardId { get; set; }
    }
}
