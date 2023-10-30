using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Queries.Payments.Get
{
    public class GetPaymentValidator : AbstractValidator<GetPayment>
    {
        public GetPaymentValidator(IDotNetStarterUnitOfWork unitOfWork) {
            RuleFor(x => x.PaymentId)
                .MustAsync((request, paymentId, cancellation) => unitOfWork.PaymentRepository
                    .AnyAsync(p => p.Id == paymentId && p.Project!.Id == request.ProjectId))
                .WithErrorCode(DomainExceptions.PaymentNotFound.Code)
                .WithMessage(DomainExceptions.PaymentNotFound.Message);

            RuleFor(x => x.UserId)
                .MustAsync((userId, cancellation) => unitOfWork.ProjectRepository
                    .AnyAsync(p => p.AgencyMemberId == userId || p.ProjectManagerId == userId || p.Talents.Any(t => t.Id == userId)))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);
        }
    }
}
