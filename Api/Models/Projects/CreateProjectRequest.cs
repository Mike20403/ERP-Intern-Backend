using System.ComponentModel.DataAnnotations;

namespace Api.Models.Projects
{
    public class CreateProjectRequest
    {
        [Required]
        public string? Name { get; set; }
    }
}
