using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Projects.Delete
{
    public sealed class DeleteProjectValidator : AbstractValidator<DeleteProject>
    {
        public DeleteProjectValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.AgencyMemberId)
                .NotEmpty()
                .MustAsync((agencyMemberId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(u => u.AgencyMemberId == agencyMemberId))
                .WithErrorCode(DomainExceptions.AgencyMemberNotFound.Code)
                .WithMessage(DomainExceptions.AgencyMemberNotFound.Message);

            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((request, projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(p => p.Id == projectId && p.AgencyMemberId == request.AgencyMemberId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync(async (projectId, cancellation) =>
                {
                    var hasStage = await unitOfWork.StageRepository.AnyAsync(p => p.ProjectId == projectId);

                    return !hasStage;
                })
                .WithErrorCode(DomainExceptions.ProjectHasStages.Code)
                .WithMessage(DomainExceptions.ProjectHasStages.Message);
        }
    }
}
