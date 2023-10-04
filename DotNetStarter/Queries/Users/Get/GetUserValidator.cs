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

            RuleForEach(x => x.RoleNames)
                .NotEmpty()
                .MustAsync((roleName, cancellation) => unitOfWork.RoleRepository.AnyAsync(u => u.Name == roleName))
                .WithErrorCode(DomainExceptions.InvalidRoleName.Code)
                .WithMessage(DomainExceptions.InvalidRoleName.Message);

            When(x => x.RoleNames is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .NotEmpty()
                    .MustAsync((request, userId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == userId && request.RoleNames!.Contains(u.Role.Name)))
                    .WithErrorCode(DomainExceptions.UserNotFound.Code)
                    .WithMessage(DomainExceptions.UserNotFound.Message);
            });
        }
    }
}
