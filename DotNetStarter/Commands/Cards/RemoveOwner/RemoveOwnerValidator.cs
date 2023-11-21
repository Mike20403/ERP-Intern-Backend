using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Cards.RemoveOwner
{
    public sealed class RemoveOwnerValidator : AbstractValidator<RemoveOwner>
    {
        public RemoveOwnerValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((request, projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(u => u.Id == projectId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.CardId)
                .NotEmpty()
                .MustAsync(async (request, cardId, cancellation) => await unitOfWork.CardRepository.AnyAsync(c => c.Id == cardId && c.Stage!.ProjectId == request.ProjectId))
                .WithErrorCode(DomainExceptions.CardNotFound.Code)
                .WithMessage(DomainExceptions.CardNotFound.Message);

            RuleFor(x => x.OwnerId)
                .NotEmpty()
                .MustAsync(async (request, ownerId, cancellation) =>
                {
                    var isTalentProject = await unitOfWork.ProjectRepository.AnyAsync(filter: p => p.Talents!.Any(t => t.Id == ownerId));
                    return isTalentProject;
                })
                .MustAsync(async (request, ownerId, cancellation) =>
                {
                    var isCardOwner = await unitOfWork.CardRepository.AnyAsync(filter: c => c.Id == request.CardId && c.Owners!.Any(t => t.Id == ownerId));
                    return isCardOwner;
                })
                .WithErrorCode(DomainExceptions.TalentNotFound.Code)
                .WithMessage(DomainExceptions.TalentNotFound.Message);

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

            When(x => x.TalentId is not null, () =>
            {
                RuleFor(x => x.TalentId)
                    .NotEmpty()
                    .MustAsync((talentId, cancellation) => unitOfWork.TalentRepository.AnyAsync(u => u.Id == talentId))
                    .WithErrorCode(DomainExceptions.TalentNotFound.Code)
                    .WithMessage(DomainExceptions.TalentNotFound.Message);

                RuleFor(x => x.ProjectId)
                    .NotEmpty()
                    .MustAsync((request, projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(p => p.Id == projectId && p.Talents.Any(t => t.Id == request.TalentId)))
                    .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                    .WithMessage(DomainExceptions.ProjectNotFound.Message);
            });
        }
    }
}