using DotNetStarter.Common.Enums;

namespace Api.Models.Projects
{
    public class ListProjectsQueryParams : ListQueryParams
    {
        public ProjectStatus? Status { get; set; }

    }
}
