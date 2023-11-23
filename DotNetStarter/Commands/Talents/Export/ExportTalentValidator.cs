using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Talents.Export
{
    public sealed class ExportTalentValidator : AbstractValidator<ExportTalent>
    {
        public ExportTalentValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.AdministratorId)
                .NotEmpty()
                .MustAsync((administratorId, cancellation) => unitOfWork.UserRepository.AnyAsync(u => u.Id == administratorId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);
        }
    }
}
