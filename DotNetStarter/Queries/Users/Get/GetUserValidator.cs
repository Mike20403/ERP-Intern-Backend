using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Queries.Users.Get
{
    public sealed class GetUserValidator : AbstractValidator<GetUser>
    {
        public GetUserValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .MustAsync((userId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == userId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);
        }
    }
}
