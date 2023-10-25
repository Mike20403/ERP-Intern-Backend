using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Otps.ResendOtp
{
    public sealed class ResendOtpValidator : AbstractValidator<ResendOtp>
    {
        public ResendOtpValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .MustAsync((request, oldOtp, cancellation) => unitOfWork.OtpRepository
                    .AnyAsync(u => u.Code == oldOtp && !u.IsUsed && u.Type == request.Type && u.ExpiredDate < DateTime.Now))
                .WithErrorCode(DomainExceptions.OtpNotFound.Code)
                .WithMessage(DomainExceptions.OtpNotFound.Message);
        }
    }
}
