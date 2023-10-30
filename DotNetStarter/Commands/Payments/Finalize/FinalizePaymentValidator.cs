using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Payments.Finalize
{
    public sealed class FinalizePaymentValidator : AbstractValidator<FinalizePayment>
    {
        public FinalizePaymentValidator(IDotNetStarterUnitOfWork unitOfWork) {
            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((request, projectId, cancellation) => unitOfWork.ProjectRepository
                    .AnyAsync(filter: p => p.Id == projectId && p.ProjectManagerId == request.ProjectManagerId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.ProjectManagerId)
                .NotEmpty()
                .MustAsync((projectManagerId, cancellation) => unitOfWork.UserRepository
                    .AnyAsync(filter: pm => pm.Id == projectManagerId && pm.Role!.Name == RoleNames.ProjectManager))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);

            RuleFor(x => x.PaymentId)
                .NotEmpty()
                .MustAsync((request, paymentId, cancellation) => unitOfWork.PaymentRepository
                    .AnyAsync(filter: p => p.Id == paymentId && p.ProjectId == request.ProjectId && p.PaymentStatus == PaymentStatus.Accepted))
                .WithErrorCode(DomainExceptions.PaymentNotFound.Code)
                .WithMessage(DomainExceptions.PaymentNotFound.Message);
        }
    }
}
