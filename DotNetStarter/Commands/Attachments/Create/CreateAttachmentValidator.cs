﻿using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Attachments.Create
{
    public sealed class CreateAttachmentValidator : AbstractValidator<CreateAttachment>
    {
        public CreateAttachmentValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(u => u.Id == projectId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.CardId)
                .NotEmpty()
                .MustAsync((request, cardId, cancellation) => unitOfWork.CardRepository.AnyAsync(c => c.Id == cardId && c.Stage!.Project!.Id == request.ProjectId))
                .WithErrorCode(DomainExceptions.CardNotFound.Code)
                .WithMessage(DomainExceptions.CardNotFound.Message);

            RuleFor(x => x.File)
                .NotEmpty();

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
        }
    }
}
