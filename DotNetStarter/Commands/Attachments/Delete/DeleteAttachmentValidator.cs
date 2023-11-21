using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Attachments.Delete
{
    public sealed class DeleteAttachmentValidator : AbstractValidator<DeleteAttachment>
    {
        public DeleteAttachmentValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(u => u.Id == projectId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.AttachmentId)
                .NotEmpty()
                .MustAsync((request, attachmentId, cancellation) => unitOfWork.AttachmentRepository.AnyAsync(u => u.Id == attachmentId && u.CardId == request.CardId))
                .WithErrorCode(DomainExceptions.AttachmentNotFound.Code)
                .WithMessage(DomainExceptions.AttachmentNotFound.Message);
             
            RuleFor(x => x.CardId)
                .NotEmpty()
                .MustAsync((request, cardId, cancellation) => unitOfWork.CardRepository.AnyAsync(c => c.Id == cardId && c.Stage!.Project!.Id == request.ProjectId))
                .WithErrorCode(DomainExceptions.CardNotFound.Code)
                .WithMessage(DomainExceptions.CardNotFound.Message);

            When(x => x.ProjectManagerId is not null, () =>
            {
                RuleFor(x => x.ProjectManagerId)
                    .MustAsync((projectManagerId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(u => u.ProjectManagerId == projectManagerId))
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
