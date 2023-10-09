using Api.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Stages
{
    public class UpdateStagesRequest
    {
        [Required]
        [MinLength(1)]
        public List<StageDto>? Stages { get; set; }
    }
}
