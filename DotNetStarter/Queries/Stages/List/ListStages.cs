using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Queries.Stages.List
{
    public sealed class ListStages : IRequest<List<Stage>>
    {
        public Guid? ProjectManagerId { get; }

        public Guid? TalentId { get; }

        public Guid ProjectId { get; }

        public ListStages(Guid? projectManagerId, Guid? talentId, Guid projectId) 
        {
            ProjectManagerId = projectManagerId;
            TalentId = talentId;
            ProjectId = projectId;
        }
    }
}
