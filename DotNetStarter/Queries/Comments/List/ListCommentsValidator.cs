using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Queries.Comments.List
{
    public sealed class ListCommentsValidator : AbstractValidator<ListComments>
    {
        public ListCommentsValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(u => u.Id == projectId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.CardId)
                .NotEmpty()
                .MustAsync((cardId, cancellation) => unitOfWork.CardRepository.AnyAsync(u => u.Id == cardId))
                .WithErrorCode(DomainExceptions.CardNotFound.Code)
                .WithMessage(DomainExceptions.CardNotFound.Message);

            When(x => x.ParentId is not null, () =>
            {
                RuleFor(x => x.ParentId)
                    .NotEmpty()
                    .MustAsync((parentId, cancellation) => unitOfWork.CommentRepository.AnyAsync(u => u.ParentId == parentId))
                    .WithErrorCode(DomainExceptions.CommentNotFound.Code)
                    .WithMessage(DomainExceptions.CommentNotFound.Message);
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

                RuleFor(x => x.CardId)
                    .NotEmpty()
                    .MustAsync((request, cardId, cancellation) => unitOfWork.CardRepository.AnyAsync(p => p.Id == cardId && p.Stage!.Project!.Talents!.Any(t => t.Id == request.TalentId)))
                    .WithErrorCode(DomainExceptions.CardNotFound.Code)
                    .WithMessage(DomainExceptions.CardNotFound.Message);
            });

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1);
        }
    } 
}
