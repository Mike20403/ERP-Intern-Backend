using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Invitations.ProcessInvitation
{
    public sealed class ProcessInvitationValidator : AbstractValidator<ProcessInvitation>
    {
        public ProcessInvitationValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.InvitationId)
                .NotEmpty()
                .MustAsync((request, invitationId, cancellation) => unitOfWork.InvitationRepository
                    .AnyAsync
                    (
                        i => i.Id == invitationId
                             && i.ProjectId == request.ProjectId
                             && i.TalentId == request.TalentId
                             && i.InvitationStatus == InvitationStatus.Pending
                    )
                )
                .WithErrorCode(DomainExceptions.InvalidInvitation.Code)
                .WithMessage(DomainExceptions.InvalidInvitation.Message);

            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(p => p.Id == projectId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.TalentId)
                .NotEmpty()
                .MustAsync((talentId, cancellation) => unitOfWork.TalentRepository.AnyAsync(t => t.Id == talentId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);
        }
    }
}
