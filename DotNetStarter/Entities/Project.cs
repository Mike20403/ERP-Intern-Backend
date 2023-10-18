using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class Project : BaseAuditingEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public ProjectStatus Status { get; set; }

        public Guid? ProjectManagerId { get; set; }

        public User? ProjectManager { get; set; }

        [Required]
        public Guid? AgencyMemberId { get; set; }

        [Required]
        public User? AgencyMember { get; set; }

        public List<Stage>? Stages { get; set; }
    }
}
