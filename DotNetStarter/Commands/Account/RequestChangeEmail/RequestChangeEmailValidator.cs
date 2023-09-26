using FluentValidation;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Commands.Account.ChangeEmailRequires;

namespace DotNetStarter.Commands.Account.ConfirmChangeEmail
{
    public sealed class RequestChangeEmailValidator : AbstractValidator<RequestChangeEmail>
    {
        public RequestChangeEmailValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.NewEmail)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("New email must be an email address")
                .NotEqual(x => x.Username)
                .WithMessage("Current email and new email must be different")
                .MustAsync(async (username, cancellation) =>
                {
                    bool exists = await unitOfWork.UserRepository.AnyAsync(u => u.Username == username && u.Status == Status.Active);
                    return !exists;
                })
                .WithErrorCode(DomainExceptions.UserAlreadyExists.Code)
                .WithMessage("This email is already exist");
        }
    }
}
