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
                if (stage.Id is not null)
                {
                    var existingStage = project.Stages.Find(s => s.Id == stage.Id);
                    existingStage.Name = stage.Name;
                    existingStage.IsNotificationEnabled = stage.IsNotificationEnabled;
                    existingStage.Order = 1000 + index;

                    return existingStage;
                }

                return new Stage
                {
                    Name = stage.Name,
                    IsNotificationEnabled = stage.IsNotificationEnabled,
                    Order = 1000 + index,
                };
            }).ToList();

            await _unitOfWork.SaveChangesAsync();

            project.Stages.ForEach(stage =>
            {
                stage.Order = stage.Order - 1000;
            });
            await _unitOfWork.SaveChangesAsync();

            return project.Stages.OrderBy(o => o.Order).ToList();
        }
    }
}
