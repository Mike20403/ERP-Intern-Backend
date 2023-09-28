using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Account.ChangePassword
{
    public sealed class ChangePasswordValidator : AbstractValidator<ChangePassword>
    {
        public ChangePasswordValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .MustAsync((userId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == userId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);

            RuleFor(x => x.CurrentPassword)
                .NotEmpty()
                .Matches(RegexPatterns.Password)
                .MustAsync(async (request, password, cancellation) =>
                {
                    var user = await unitOfWork.UserRepository.FindAsync(filter: u => u.Id == request.UserId);
                    return BCrypt.Net.BCrypt.Verify(password, user!.Password);
                })
                .WithErrorCode(DomainExceptions.IncorrectPassword.Code)
                .WithMessage(DomainExceptions.IncorrectPassword.Message);

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .Matches(RegexPatterns.Password)
                .NotEqual(cp => cp.CurrentPassword)
                .WithErrorCode(DomainExceptions.InvalidPassword.Code)
                .WithMessage(DomainExceptions.InvalidPassword.Message);
        }
    }
}
