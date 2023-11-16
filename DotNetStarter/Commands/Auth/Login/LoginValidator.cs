using FluentValidation;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;

namespace DotNetStarter.Commands.Auth.Login
{
    public sealed class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator(IDotNetStarterUnitOfWork unitOfWork) {
            RuleFor(x => x.Username)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Username must be an email address")
                .MustAsync((username, cancellation) => unitOfWork.UserRepository
                    .AnyAsync(u => u.Username == username && new[] { Status.Active, Status.Deleting , Status.ChangingPasswordRequired }.Contains(u.Status)))
                .WithErrorCode(DomainExceptions.BadCredentials.Code)
                .WithMessage(DomainExceptions.BadCredentials.Message);

            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches(RegexPatterns.Password)
                .WithMessage(DomainExceptions.InvalidPassword.Message)
                .MustAsync(async (request, password, cancellation) =>
                {
                    var user = await unitOfWork.UserRepository.FindAsync(filter: u => u.Username == request.Username);
                    return BCrypt.Net.BCrypt.Verify(password, user!.Password);
                })
                .WithErrorCode(DomainExceptions.BadCredentials.Code)
                .WithMessage(DomainExceptions.BadCredentials.Message);
        }
    }
}
