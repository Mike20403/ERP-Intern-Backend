using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Queries.Talents.Get
{
    public class GetTalentValidator : AbstractValidator<GetTalent>
    {
        public GetTalentValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .MustAsync((request, userId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == userId && u.Role!.Name == RoleNames.Talent))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);
        }
    }
}
