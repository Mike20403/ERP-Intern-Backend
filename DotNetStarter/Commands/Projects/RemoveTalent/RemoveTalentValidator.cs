using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Projects.RemoveTalent
{
    public sealed class RemoveTalentValidator : AbstractValidator<RemoveTalent>
    {
        public RemoveTalentValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((request, projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(u => u.Id == projectId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.TalentId)
                .NotEmpty()
                .MustAsync(async (request, talentId, cancellation) =>
                {
                    var isTalentProject = await unitOfWork.ProjectRepository.AnyAsync(filter: p => p.Id == request.ProjectId && p.Talents!.Any(t => t.Id == talentId));
                    return isTalentProject;
                })
                .WithErrorCode(DomainExceptions.TalentNotFound.Code)
                .WithMessage(DomainExceptions.TalentNotFound.Message);

            When(x => x.AgencyMemberId is not null, () =>
            {
                RuleFor(x => x.AgencyMemberId)
                    .NotEmpty()
                    .MustAsync((agencyMemberId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == agencyMemberId))
                    .WithErrorCode(DomainExceptions.AgencyMemberNotFound.Code)
                    .WithMessage(DomainExceptions.AgencyMemberNotFound.Message);

                RuleFor(x => x.ProjectId)
                    .NotEmpty()
                    .MustAsync((request, projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(p => p.Id == projectId && p.AgencyMemberId == request.AgencyMemberId))
                    .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                    .WithMessage(DomainExceptions.ProjectNotFound.Message);
            });

            When(x => x.ProjectManagerId is not null, () =>
            {
                RuleFor(x => x.ProjectManagerId)
                    .NotEmpty()
                    .MustAsync((projectManagerId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == projectManagerId))
                    .WithErrorCode(DomainExceptions.ProjectManagerNotFound.Code)
                    .WithMessage(DomainExceptions.ProjectManagerNotFound.Message);

                RuleFor(x => x.ProjectId)
                    .NotEmpty()
                    .MustAsync((request, projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(p => p.Id == projectId && p.ProjectManagerId == request.ProjectManagerId))
                    .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                    .WithMessage(DomainExceptions.ProjectNotFound.Message);
            });
        }
    }
}
