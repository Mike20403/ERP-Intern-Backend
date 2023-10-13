using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Cards.MoveCards
{
    public sealed class MovingCardValidator : AbstractValidator<MovingCard>, IExcludedValidator
    {
        public MovingCardValidator(IDotNetStarterUnitOfWork unitOfWork, Guid projectId)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .MustAsync((request, cardId, cancellation) => unitOfWork.CardRepository.AnyAsync(c => c.Id == cardId && c.Stage.ProjectId == projectId))
                .WithErrorCode(DomainExceptions.CardNotFound.Code)
                .WithMessage(DomainExceptions.CardNotFound.Message);

            RuleFor(x => x.StageId)
                .NotEmpty()
                .MustAsync((request, stageId, cancellation) => unitOfWork.StageRepository.AnyAsync(s => s.Id == stageId && s.ProjectId == projectId))
                .WithErrorCode(DomainExceptions.StageNotFound.Code)
                .WithMessage(DomainExceptions.StageNotFound.Message);

            When(x => x.PrevCardId is not null, () =>
            {
                RuleFor(x => x.PrevCardId)
                    .NotEmpty()
                    .MustAsync((request, prevCardId, cancellation) => unitOfWork.CardRepository.AnyAsync(c => c.Id == prevCardId && c.Stage.ProjectId == projectId))
                    .WithErrorCode(DomainExceptions.CardNotFound.Code)
                    .WithMessage(DomainExceptions.CardNotFound.Message);
            });

            When(x => x.NextCardId is not null, () =>
            {
                RuleFor(x => x.NextCardId)
                    .NotEmpty()
                    .MustAsync((request, nextCardId, cancellation) => unitOfWork.CardRepository.AnyAsync(c => c.Id == nextCardId && c.Stage.ProjectId == projectId))
                    .WithErrorCode(DomainExceptions.CardNotFound.Code)
                    .WithMessage(DomainExceptions.CardNotFound.Message);
            });
        }
    }
}
