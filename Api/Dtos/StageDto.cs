using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class StageDto
    {
        public Guid? Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
