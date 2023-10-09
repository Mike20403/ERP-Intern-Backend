using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Stages.Update
{
    public sealed class UpdateStagesHandler : BaseRequestHandler<UpdateStages, List<Stage>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public UpdateStagesHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task<List<Stage>> Process(UpdateStages request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.ProjectRepository.FindAsync(ClassUtils.GetPropertyName<Project>(p => p.Stages), p => p.Id == request.ProjectId);

            var deletingStages = project!.Stages!.Where(s => request.Stages.All(ss => ss.Id != s.Id)).ToList();
            await _unitOfWork.StageRepository.DeletesAsync(deletingStages.ToArray());

            project.Stages = request.Stages.Select((stage, index) =>
            {
                var mapped = new Stage
                {
                    Name = stage.Name,
                    Order = index,
                };

                if (stage.Id is not null)
                {
                    mapped.Id = stage.Id!.Value;
                }

                return mapped;
            }).ToList();

            await _unitOfWork.SaveChangesAsync();

            return project.Stages.OrderBy(o => o.Order).ToList();
        }
    }
}
