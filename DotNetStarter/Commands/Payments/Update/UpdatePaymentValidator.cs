using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace DotNetStarter.Commands.Payments.Update
{
    public sealed class UpdatePaymentValidator : AbstractValidator<UpdatePayment>
    {
        public UpdatePaymentValidator(IDotNetStarterUnitOfWork unitOfWork) {
            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(filter: p => p.Id == projectId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.PaymentId)
                .NotEmpty()
                .MustAsync((request, paymentId, cancellation) => unitOfWork.PaymentRepository
                    .AnyAsync(filter: p => p.Id == paymentId && p.ProjectId == request.ProjectId && p.PaymentStatus == PaymentStatus.Draft))
                .WithErrorCode(DomainExceptions.PaymentNotFound.Code)
                .WithMessage(DomainExceptions.PaymentNotFound.Message);

            RuleFor(x => x.TalentId)
                .NotEmpty()
                .MustAsync((talentId, cancellation) => unitOfWork.TalentRepository.AnyAsync(filter: t => t.Id == talentId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message)
                .MustAsync(async (request, talentId, cancellation) =>
                {
                    var isTalentProject = await unitOfWork.ProjectRepository.AnyAsync(filter: p => p.Talents!.Any(t => t.Id == talentId));
                    return isTalentProject;
                })
                .WithErrorCode(DomainExceptions.NotProjectTalent.Code)
                .WithMessage(DomainExceptions.NotProjectTalent.Message);

            RuleFor(x => x.CardIds)
                .NotEmpty();

            RuleForEach(x => x.CardIds)
                .NotEmpty()
                .MustAsync((request, cardId, cancellation) => unitOfWork.CardRepository
                    .AnyAsync(c => c.Id == cardId && c.Stage!.ProjectId == request.ProjectId))
                .WithErrorCode(DomainExceptions.CardNotFound.Code)
                .WithMessage(DomainExceptions.CardNotFound.Message);
        }
    }
}
