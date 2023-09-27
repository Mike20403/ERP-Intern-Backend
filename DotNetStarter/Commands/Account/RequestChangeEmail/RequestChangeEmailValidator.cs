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
            RuleFor(x => x.UserId)
                .NotEmpty()
                .MustAsync((userId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == userId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);

            RuleFor(x => x.NewEmail)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("New email must be an email address")
                .MustAsync(async (newEmail, cancellation) =>
                {
                    bool exists = await unitOfWork.UserRepository.AnyAsync(u => u.Username == newEmail);
                    return !exists;
                })
                .WithErrorCode(DomainExceptions.EmailAlreadyExists.Code)
                .WithMessage(DomainExceptions.EmailAlreadyExists.Message);
        }
    }
}
