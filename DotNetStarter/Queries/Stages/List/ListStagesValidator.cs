using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Queries.Stages.List
{
    public sealed class ListStagesValidator : AbstractValidator<ListStages>
    {
        public ListStagesValidator(IDotNetStarterUnitOfWork unitOfWork)
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
        }
    }
}
