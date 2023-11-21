using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Cards.Create
{
    public sealed class CreateCardValidator : AbstractValidator<CreateCard>
    {
        public CreateCardValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(p => p.Id == projectId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.StageId)
                .NotEmpty()
                .MustAsync((request, stageId, cancellation) => unitOfWork.StageRepository.AnyAsync(s => s.Id == stageId && s.ProjectId == request.ProjectId))
                .WithErrorCode(DomainExceptions.StageNotFound.Code)
                .WithMessage(DomainExceptions.StageNotFound.Message);

            When(x => x.PrevCardId is not null, () =>
            {
                RuleFor(x => x.PrevCardId)
                    .NotEmpty()
                    .MustAsync((request, prevCardId, cancellation) => unitOfWork.CardRepository.AnyAsync(c => c.Id == prevCardId && c.StageId == request.StageId))
                    .WithErrorCode(DomainExceptions.CardNotFound.Code)
                    .WithMessage(DomainExceptions.CardNotFound.Message);
            });

            When(x => x.NextCardId is not null, () =>
            {
                RuleFor(x => x.NextCardId)
                    .NotEmpty()
                    .MustAsync((request, nextCardId, cancellation) => unitOfWork.CardRepository.AnyAsync(c => c.Id == nextCardId && c.StageId == request.StageId))
                    .WithErrorCode(DomainExceptions.CardNotFound.Code)
                    .WithMessage(DomainExceptions.CardNotFound.Message);
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
