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
                .NotEmpty()
                .Must(stages => stages.Count == stages.DistinctBy(stages => stages.Name).Count())
                .WithMessage("Stage names must be unique within the project.");
        }
    }
}
