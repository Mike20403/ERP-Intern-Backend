using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Queries.Invitations.List.TalentInvitation
{
    public sealed class ListTalentInvitationsValidator : AbstractValidator<ListTalentInvitations>
    {
        public ListTalentInvitationsValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.TalentId)
                .NotEmpty()
                .MustAsync((talentId, cancellation) => unitOfWork.TalentRepository.AnyAsync(filter: t => t.Id == talentId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);
        }
    }
}
