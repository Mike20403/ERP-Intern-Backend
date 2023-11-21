using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Users.Create
{
    public sealed class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Username must be an email address")
                .MustAsync(async (username, cancellation) =>
                {
                    var isExisted = await unitOfWork.UserRepository.AnyAsync(u => u.Username == username);

                    return !isExisted;
                })
                .WithErrorCode(DomainExceptions.UserAlreadyExists.Code)
                .WithMessage(DomainExceptions.UserAlreadyExists.Message);

            RuleFor(x => x.Firstname)
                .NotEmpty();

            RuleFor(x => x.Lastname)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches(RegexPatterns.Password)
                .WithMessage(DomainExceptions.InvalidPassword.Message);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(RegexPatterns.PhoneNumber)
                .WithMessage(DomainExceptions.InvalidPhoneNumber.Message)
                .MustAsync(async (phoneNumber, cancellation) =>
                {
                    var isExisted = await unitOfWork.UserRepository.AnyAsync(u => u.PhoneNumber == phoneNumber);

                    return !isExisted;
                })
                .WithErrorCode(DomainExceptions.PhoneNumberAlreadyExists.Code)
                .WithMessage(DomainExceptions.PhoneNumberAlreadyExists.Message);

            RuleFor(x => x.RoleName)
                .NotEmpty()
                .MustAsync((roleName, cancellation) => unitOfWork.RoleRepository.AnyAsync(u => u.Name == roleName))
                .WithErrorCode(DomainExceptions.InvalidRoleName.Code)
                .WithMessage(DomainExceptions.InvalidRoleName.Message);

            RuleForEach(x => x.PrivilegeNames)
                .MustAsync((request, privilegeName, cancellation) => unitOfWork.PrivilegeRepository
                    .AnyAsync(p => p.Name == privilegeName && p.Roles.Any(r => r.Name == request!.RoleName)))
                .WithErrorCode(DomainExceptions.PrivilegeNotFound.Code)
                .WithMessage(DomainExceptions.PrivilegeNotFound.Message);
        }
    }
}
