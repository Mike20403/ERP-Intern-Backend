using FluentValidation;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;

namespace DotNetStarter.Commands.Auth.ActivateAccount
{
    public sealed class ActivateAccountValidator : AbstractValidator<ActivateAccount>
    {
        public ActivateAccountValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Username must be an email address")
                .MustAsync((username, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Username == username && u.Status == Status.Inactive))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);

            RuleFor(x => x.ActiveCode)
                .NotEmpty()
                .MustAsync((code, cancellation) => unitOfWork.OtpRepository.AnyAsync(o => o.Code == code && !o.IsUsed && o.Type == OtpType.ActivateAccount))
                .WithErrorCode(DomainExceptions.InvalidOtp.Code)
                .WithMessage(DomainExceptions.InvalidOtp.Message)
                .MustAsync((code, cancellation) => unitOfWork.OtpRepository.AnyAsync(o => o.ExpiredDate >= DateTime.Now))
                .WithErrorCode(DomainExceptions.OtpExpired.Code)
                .WithMessage(DomainExceptions.OtpExpired.Message); 
        }
    }
}
