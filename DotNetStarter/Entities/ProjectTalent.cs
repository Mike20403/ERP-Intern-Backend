using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class ProjectTalent
    {
        [Required]
        public Guid? ProjectId { get; set; }
        
        [Required]
        public Project? Project { get; set; }

        [Required]
        public Guid? TalentId { get; set; }

        [Required]
        public Talent? Talent { get; set;}
    }
}
