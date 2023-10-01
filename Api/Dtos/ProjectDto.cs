using DotNetStarter.Common.Enums;

namespace Api.Dtos
{
    public class ProjectDto
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public ProjectStatus? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
