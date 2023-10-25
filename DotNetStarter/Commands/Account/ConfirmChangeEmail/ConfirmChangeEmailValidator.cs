using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Account.ConfirmChangeEmail
{
    public sealed class ConfirmChangeEmailValidator : AbstractValidator<ConfirmChangeEmail>
    {
        public ConfirmChangeEmailValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .MustAsync((userId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == userId && u.Status == Status.Active))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("New email must be an email address")
                .MustAsync(async (username, cancellation) => {
                    bool exists = await unitOfWork.UserRepository.AnyAsync(u => u.Username == username);
                    return !exists;
                })
                .WithErrorCode(DomainExceptions.EmailAlreadyExists.Code)
                .WithMessage(DomainExceptions.EmailAlreadyExists.Message);

            RuleFor(x => x.ActiveCode)
                .NotEmpty()
                .MustAsync((request, code, cancellation) => unitOfWork.OtpRepository
                    .AnyAsync(o => o.Code == code && o.UserId == request.UserId && !o.IsUsed && o.Type == OtpType.ChangeEmail))
                .WithErrorCode(DomainExceptions.InvalidOtp.Code)
                .WithMessage(DomainExceptions.InvalidOtp.Message)
                .MustAsync((code, cancellation) => unitOfWork.OtpRepository.AnyAsync(o => o.ExpiredDate >= DateTime.Now))
                .WithErrorCode(DomainExceptions.OtpExpired.Code)
                .WithMessage(DomainExceptions.OtpExpired.Message);    
        }
    }
}
