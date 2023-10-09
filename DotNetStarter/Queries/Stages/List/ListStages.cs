using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Queries.Stages.List
{
    public sealed class ListStages : IRequest<List<Stage>>
    {
        public Guid ProjectManagerId { get; }

        public Guid ProjectId { get; }

        public ListStages(Guid projectManagerId, Guid projectId) 
        {
            ProjectManagerId = projectManagerId;
            ProjectId = projectId;
        }
    }
}
