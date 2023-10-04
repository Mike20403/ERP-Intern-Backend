using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Users.Update
{
    public sealed class UpdateUserValidator : AbstractValidator<UpdateUser>
    {
        public UpdateUserValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .MustAsync((userId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == userId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);

            RuleFor(x => x.Firstname)
                .NotEmpty();

            RuleFor(x => x.Lastname)
                .NotEmpty();

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(RegexPatterns.PhoneNumber)
                .WithMessage(DomainExceptions.InvalidPhoneNumber.Message)
                .MustAsync(async (request, phoneNumber, cancellation) =>
                {
                    var isExisted = await unitOfWork.UserRepository.AnyAsync(u => u.Id != request.UserId && u.PhoneNumber == phoneNumber);

                    return !isExisted;
                })
                .WithErrorCode(DomainExceptions.PhoneNumberAlreadyExists.Code)
                .WithMessage(DomainExceptions.PhoneNumberAlreadyExists.Message);

            RuleForEach(x => x.RoleNames)
                .NotEmpty()
                .MustAsync((roleName, cancellation) => unitOfWork.RoleRepository.AnyAsync(u => u.Name == roleName))
                .WithErrorCode(DomainExceptions.InvalidRoleName.Code)
                .WithMessage(DomainExceptions.InvalidRoleName.Message);

            When(x => x.RoleNames is not null, () =>
            {
                RuleFor(x => x.UserId)
                .NotEmpty()
                .MustAsync((request, userId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == userId && request.RoleNames!.Contains(u.Role!.Name)))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);
            });
        }
    }
}
