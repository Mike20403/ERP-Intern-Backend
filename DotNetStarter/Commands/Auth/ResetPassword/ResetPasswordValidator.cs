using FluentValidation;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;

namespace DotNetStarter.Commands.Auth.ResetPassword
{
    public sealed class ResetPasswordValidator : AbstractValidator<ResetPassword>
    {
        public ResetPasswordValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Username must be an email address")
                .MustAsync((username, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Username == username && u.Status == Status.Active))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);

            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches(RegexPatterns.Password)
                .WithMessage(DomainExceptions.InvalidPassword.Message);

            RuleFor(x => x.Code)
                .NotEmpty()
                .MustAsync(async (request, code, cancellation) =>
                {
                    var user = await unitOfWork.UserRepository.FindAsync(filter: u => u.Username == request.Username);

                    return await unitOfWork.OtpRepository.AnyAsync(o => o.Code == code && o.UserId == user!.Id && !o.IsUsed && o.ExpiredDate >= DateTime.Now);
                })
                .WithErrorCode(DomainExceptions.InvalidOtp.Code)
                .WithMessage(DomainExceptions.InvalidOtp.Message);
        }
    }
}
