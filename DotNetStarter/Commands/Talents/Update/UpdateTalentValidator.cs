using DotNetStarter.Commands.Talents.Update;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Talents.Update
{
    public sealed class UpdateTalentValidator : AbstractValidator<UpdateTalent>
    {
        public UpdateTalentValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .MustAsync((request, userId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == userId && u.Role!.Name == RoleNames.Talent))
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

            RuleFor(x => x.Gender)
                .NotEmpty();
        }
    }
}
