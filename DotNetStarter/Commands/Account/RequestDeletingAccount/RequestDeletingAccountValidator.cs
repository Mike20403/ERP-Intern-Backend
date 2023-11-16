using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Account.RequestDeletingAccount
{
    public sealed class RequestDeletingAccountValidator : AbstractValidator<RequestDeletingAccount>
    {
        public RequestDeletingAccountValidator(IDotNetStarterUnitOfWork unitOfWork) {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .MustAsync((userId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == userId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);
        }
    }
}
