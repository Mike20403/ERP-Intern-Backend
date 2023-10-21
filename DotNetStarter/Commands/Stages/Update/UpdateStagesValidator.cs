using DotNetStarter.Commands.Stages.Update;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Stages.Upsert
{
    public sealed class UpdateStagesValidator : AbstractValidator<UpdateStages>
    {
        public UpdateStagesValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ProjectManagerId)
                .NotEmpty()
                .MustAsync((projectManagerId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(u => u.ProjectManagerId == projectManagerId))
                .WithErrorCode(DomainExceptions.ProjectManagerNotFound.Code)
                .WithMessage(DomainExceptions.ProjectManagerNotFound.Message);

            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((request, projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(p => p.Id == projectId && p.ProjectManagerId == request.ProjectManagerId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.Stages)
                .Must(stages => stages.Count == stages.DistinctBy(stages => stages.Name).Count())
                .WithMessage("Stage names must be unique within the project.")
                .MustAsync(async (request, stages, cancellation) =>
                {
                    var stageIds = request.Stages.Where(s => s.Id.HasValue).Select(s => s.Id!.Value);

                    var deletingStages = stageIds.Any()
                        ? await unitOfWork.StageRepository.ListAsync(filter: s => s.ProjectId == request.ProjectId && !stageIds.Contains(s.Id))
                        : await unitOfWork.StageRepository.ListAsync(filter: s => s.ProjectId == request.ProjectId);
                    var deletingStageIds = deletingStages.Select(s => s.Id);

                    if (!deletingStageIds.Any())
                    {
                        return true;
                    }

                    var hasCard = await unitOfWork.CardRepository.AnyAsync(c => deletingStageIds.Contains(c.StageId));
                    return !hasCard;
                })
                 .WithErrorCode(DomainExceptions.StageHasCards.Code)
                 .WithMessage(DomainExceptions.StageHasCards.Message);
        }
    }
}