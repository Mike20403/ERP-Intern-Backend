using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Projects.Create
{
    public sealed class CreateProjectValidator : AbstractValidator<CreateProject>
    {
        public CreateProjectValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.AgencyMemberId)
                .NotEmpty()
                .MustAsync((agencyMemberId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == agencyMemberId))
                .WithErrorCode(DomainExceptions.AgencyMemberNotFound.Code)
                .WithMessage(DomainExceptions.AgencyMemberNotFound.Message);

            RuleFor(x => x.Name)
                .NotEmpty();
        }
    } 
}
