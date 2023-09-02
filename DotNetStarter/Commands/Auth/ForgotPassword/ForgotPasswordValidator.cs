using FluentValidation;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;

namespace DotNetStarter.Commands.Auth.ForgotPassword
{
    public sealed class ForgotPasswordValidator : AbstractValidator<ForgotPassword>
    {
        public ForgotPasswordValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Username must be an email address")
                .MustAsync((username, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Username == username && u.Status == Status.Active))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);
        }
    }
}
