using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Queries.Payments.List
{
    public class ListPaymentsValidator : AbstractValidator<ListPayments>
    {
        public ListPaymentsValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ProjectId)
                .MustAsync((request, projectId, cancellation) => unitOfWork.ProjectRepository
                    .AnyAsync(
                        p => p.Id == projectId
                             || p.ProjectManagerId == request.StaffmemberId
                             || p.AgencyMemberId == request.StaffmemberId
                    ))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1);
        }
    }
}
