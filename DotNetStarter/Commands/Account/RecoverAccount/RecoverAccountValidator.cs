using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Account.RecoverAccount
{
    public sealed class RecoverAccountValidator : AbstractValidator<RecoverAccount>
    {
        public RecoverAccountValidator(IDotNetStarterUnitOfWork unitOfWork) {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .MustAsync((userId, cancellation) => unitOfWork.UserRepository
                    .AnyAsync(u => u.Id == userId && u.Status == Status.Deleting))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);
        }
    }
}
