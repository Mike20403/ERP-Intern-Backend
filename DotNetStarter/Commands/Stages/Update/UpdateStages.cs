using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Stages.Update
{
    public sealed class UpdateStages : IRequest<List<Stage>>
    {
        public Guid ProjectManagerId { get; }

        public Guid ProjectId { get; }

        public List<UpsertStage> Stages { get; }

        public UpdateStages(Guid projectManagerId, Guid projectId, List<UpsertStage> stages)
        {
            ProjectManagerId = projectManagerId;
            ProjectId = projectId;
            Stages = stages;
        }
    }
}
