using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Comments.Update
{
    public sealed class UpdateCommentValidator : AbstractValidator<UpdateComment>
    {
        public UpdateCommentValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(u => u.Id == projectId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.CardId)
            .NotEmpty()
                .MustAsync((request, cardId, cancellation) => unitOfWork.CardRepository.AnyAsync(u => u.Id == cardId && u.Stage.Project.Id == request.ProjectId))
                .WithErrorCode(DomainExceptions.CardNotFound.Code)
                .WithMessage(DomainExceptions.CardNotFound.Message);

            RuleFor(x => x.CommentId)
                .NotEmpty()
                .MustAsync((request, commentId, cancellation) => unitOfWork.CommentRepository.AnyAsync(u => u.Id == commentId && 
                                                                                                            u.CardId == request.CardId && 
                                                                                                            u.Card.Stage.Project.Id == request.ProjectId))
                .WithErrorCode(DomainExceptions.CommentNotFound.Code)
                .WithMessage(DomainExceptions.CommentNotFound.Message)

                .MustAsync((request, commentId, cancellation) => unitOfWork.CommentRepository.AnyAsync(u => u.Id == commentId && u.UserId == request.OwnerId))
                .WithErrorCode(DomainExceptions.CommentNotYours.Code)
                .WithMessage(DomainExceptions.CommentNotYours.Message);

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.OwnerId)
                .NotEmpty()
                .MustAsync((ownerId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == ownerId))
                .MustAsync((ownerId, cancellation) => unitOfWork.CommentRepository.AnyAsync(u => u.UserId == ownerId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);
        }
    }
}
