using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Auth.LoginWithBackup
{
    public sealed class LoginWithBackupValidator : AbstractValidator<LoginWithBackup>
    {
        public LoginWithBackupValidator(IDotNetStarterUnitOfWork unitOfWork) {
            RuleFor(x => x.Username)
                .NotEmpty()
                .MustAsync((username, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Username == username))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);

            RuleFor(x => x.BackupCode)
                .NotEmpty()
                .MustAsync((backupCode, cancellation) => unitOfWork.TwoFactorsBackupRepository.AnyAsync(c => c.Code == backupCode && !c.IsUsed))
                .WithErrorCode(DomainExceptions.InvalidTwoFactorsCode.Code)
                .WithMessage(DomainExceptions.InvalidTwoFactorsCode.Message);
        }
    }
}
 