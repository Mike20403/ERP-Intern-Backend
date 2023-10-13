using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Cards.MoveCards
{
    public sealed class MoveCardsValidator : AbstractValidator<MoveCards>
    {
        public MoveCardsValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(p => p.Id == projectId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleForEach(x => x.Cards).SetValidator(request => new MovingCardValidator(unitOfWork, request.ProjectId));

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