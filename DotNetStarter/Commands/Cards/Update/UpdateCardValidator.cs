using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Cards.Update
{
    public sealed class UpdateCardValidator : AbstractValidator<UpdateCard>
    {
        public UpdateCardValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(p => p.Id == projectId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.CardId)
                .NotEmpty()
                .MustAsync((request, cardId, cancellation) => unitOfWork.CardRepository.AnyAsync(c => c.Id == cardId && c.Stage.ProjectId == request.ProjectId))
                .WithErrorCode(DomainExceptions.CardNotFound.Code)
                .WithMessage(DomainExceptions.CardNotFound.Message);

            RuleFor(x => x.Name)
                .NotEmpty();

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
