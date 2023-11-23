using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;
using OtpNet;

namespace DotNetStarter.Commands.Account.Enable2fa
{
    public sealed class Enable2faValidator : AbstractValidator<Enable2fa>
    {
        public Enable2faValidator(IDotNetStarterUnitOfWork unitOfWork) {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .MustAsync((userId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == userId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);

            RuleFor(x => x.TwoFactorsCode)
                .NotEmpty()
                .MustAsync(async (request, twoFactorsCode, cancellation) =>
                {
                    var user = await unitOfWork.UserRepository.GetByIdAsync(request.UserId);

                    var totp = new Totp(Base32Encoding.ToBytes(user!.Secret));

                    return totp.VerifyTotp(DateTime.UtcNow, request.TwoFactorsCode, out long timeStepMatched, VerificationWindow.RfcSpecifiedNetworkDelay);
                })
                .WithErrorCode(DomainExceptions.InvalidTwoFactorsCode.Code)
                .WithMessage(DomainExceptions.InvalidTwoFactorsCode.Message);
        }
    }
}
