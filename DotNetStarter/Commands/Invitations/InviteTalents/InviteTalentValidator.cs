using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Invitations.InviteTalents
{
    public sealed class InviteTalentValidator : AbstractValidator<InviteTalent>, IExcludedValidator
    {
        public InviteTalentValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            When(x => x.Id is null, () =>
            {
                RuleFor(x => x.Email)
                    .NotEmpty()
                    .EmailAddress()
                    .WithMessage("Invalid email format")
                    .MustAsync(async (email, cancellation) =>
                    {
                        var isExist = await unitOfWork.UserRepository.AnyAsync(filter: u => u.Username == email);
                        return !isExist;
                    })
                    .WithErrorCode(DomainExceptions.EmailAlreadyExists.Code)
                    .WithMessage(DomainExceptions.EmailAlreadyExists.Message);
            });

            When(x => x.Email is null, () =>
            {
                RuleFor(x => x.Id)
                    .NotEmpty()
                    .MustAsync((talentId, cancellation) => unitOfWork.UserRepository.AnyAsync(filter: u => u.Id == talentId && u.Role!.Name == RoleNames.Talent))
                    .WithErrorCode(DomainExceptions.UserNotFound.Code)
                    .WithMessage(DomainExceptions.UserNotFound.Message);
            });
        }
    }
}
