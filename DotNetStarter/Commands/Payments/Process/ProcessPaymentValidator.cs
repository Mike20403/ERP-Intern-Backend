using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Payments.Process
{
    public sealed class ProcessPaymentValidator : AbstractValidator<ProcessPayment>
    {
        public ProcessPaymentValidator(IDotNetStarterUnitOfWork unitOfWork) {
            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((request, projectId, cancellation) => unitOfWork.ProjectRepository
                    .AnyAsync(filter: p => p.Id == projectId && p.AgencyMemberId == request.AgencyMemberId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.AgencyMemberId)
                .NotEmpty()
                .MustAsync((agencyMemberId, cancellation) => unitOfWork.UserRepository
                    .AnyAsync(filter: a => a.Id == agencyMemberId && a.Role!.Name == RoleNames.AgencyMember))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);

            RuleFor(x => x.PaymentId)
                .NotEmpty()
                .MustAsync((request, paymentId, cancellation) => unitOfWork.PaymentRepository
                    .AnyAsync(filter: p => p.Id == paymentId && p.ProjectId == request.ProjectId && p.PaymentStatus == PaymentStatus.Draft))
                .WithErrorCode(DomainExceptions.PaymentNotFound.Code)
                .WithMessage(DomainExceptions.PaymentNotFound.Message);
        }
    }
}
