using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Account.Configure2fa
{
    public sealed class Configure2faValidator : AbstractValidator<Configure2fa>
    {
        public Configure2faValidator(IDotNetStarterUnitOfWork unitOfWork) {
            RuleFor(x => x.UserId)
                .MustAsync((userId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == userId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);
        }
    }
}
