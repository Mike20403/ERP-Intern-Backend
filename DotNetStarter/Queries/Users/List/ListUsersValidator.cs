using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Queries.Users.List
{
    public sealed class ListUsersValidator : AbstractValidator<ListUsers>
    {
        public ListUsersValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1);

            RuleForEach(x => x.RoleNames)
                .NotEmpty()
                .MustAsync((roleName, cancellation) => unitOfWork.RoleRepository.AnyAsync(u => u.Name == roleName))
                .WithErrorCode(DomainExceptions.InvalidRoleName.Code)
                .WithMessage(DomainExceptions.InvalidRoleName.Message);
        }
    }
}
