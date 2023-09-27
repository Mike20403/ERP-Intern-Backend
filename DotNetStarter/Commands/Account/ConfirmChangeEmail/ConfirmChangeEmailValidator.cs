using FluentValidation;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;

namespace DotNetStarter.Commands.Account.ConfirmChangeEmail
{
    public sealed class ConfirmChangeEmailValidator : AbstractValidator<ConfirmChangeEmail>
    {
        public ConfirmChangeEmailValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.CurrentEmail)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Current must be an email address")
                .MustAsync((username, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Username == username && u.Status == Status.Active))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);

            RuleFor(x => x.NewEmail)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("New email must be an email address")
                .NotEqual(x => x.CurrentEmail)
                .WithMessage("Current email and new email must be different")
                .MustAsync(async (username, cancellation) => {
                    bool exists = await unitOfWork.UserRepository.AnyAsync(u => u.Username == username);
                    return !exists;
                })
                .WithErrorCode(DomainExceptions.EmailAlreadyExists.Code)
                .WithMessage(DomainExceptions.EmailAlreadyExists.Message);

            RuleFor(x => x.ActiveCode)
                .NotEmpty()
                .MustAsync((code, cancellation) => unitOfWork.OtpRepository
                    .AnyAsync(o => o.Code == code && !o.IsUsed && o.Type == OtpType.ChangeEmail && o.ExpiredDate >= DateTime.Now))
                .WithErrorCode(DomainExceptions.InvalidOtp.Code)
                .WithMessage(DomainExceptions.InvalidOtp.Message);
        }
    }
}
