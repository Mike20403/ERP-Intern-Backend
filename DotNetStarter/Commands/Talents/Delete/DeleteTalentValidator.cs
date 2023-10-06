using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Talents.Delete
{
    public sealed class DeleteTalentValidator : AbstractValidator<DeleteTalent>
    {
        public DeleteTalentValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .MustAsync((request, userId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == userId && u.Role!.Name == RoleNames.Talent))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);
        }
    }
}
