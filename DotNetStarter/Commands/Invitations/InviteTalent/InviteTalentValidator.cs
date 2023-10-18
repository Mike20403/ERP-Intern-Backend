using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using FluentValidation;
using System.Linq.Expressions;

namespace DotNetStarter.Commands.Invitations.InviteTalent
{
    public sealed class InviteTalentValidator : AbstractValidator<InviteTalent>
    {
        public InviteTalentValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(filter: p => p.Id == projectId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.InviterId)
                .NotEmpty()
                .MustAsync((inviterId, cancellation) => unitOfWork.UserRepository.AnyAsync(filter: u => u.Id == inviterId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);

            RuleFor(x => x.InviterRole)
                .NotEmpty()
                .MustAsync((inviterRole, cancellation) => unitOfWork.RoleRepository.AnyAsync(filter: r => r.Name == inviterRole))
                .WithErrorCode(DomainExceptions.InvalidRoleName.Code)
                .WithMessage(DomainExceptions.InvalidRoleName.Message);

            When(x => x.TalentId is null, () => {
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

                // Invitation via Email (non-exist talent) can only be done by Agency Member
                RuleFor(x => x.InviterRole)
                    .Equal(RoleNames.AgencyMember)
                    .WithErrorCode(DomainExceptions.InvalidPrivilege.Code)
                    .WithMessage(DomainExceptions.InvalidPrivilege.Message);
            });

            When(x => x.Email is null, () => {
                RuleFor(x => x.TalentId)
                    .NotEmpty()
                    .MustAsync((talentId, cancellation) => unitOfWork.UserRepository.AnyAsync(filter: u => u.Id == talentId && u.Role!.Name == RoleNames.Talent))
                    .WithErrorCode(DomainExceptions.UserNotFound.Code)
                    .WithMessage(DomainExceptions.UserNotFound.Message);
            });

            When(x => x.InviterRole is not null, () =>
            {
                RuleFor(x => x.InviterId)
                    .MustAsync(async (invitation, request, cancellation) =>
                    {
                        var filter = new List<Expression<Func<Project, bool>>>() { p => p.Id == invitation.ProjectId };

                        if (invitation.InviterRole == RoleNames.AgencyMember)
                        {
                            filter.Add(u => u.AgencyMemberId == invitation.InviterId);
                        }

                        if (invitation.InviterRole == RoleNames.ProjectManager)
                        {
                            filter.Add(u => u.ProjectManagerId == invitation.InviterId);
                        }

                        return await unitOfWork.ProjectRepository.AnyAsync(filter.ToArray());
                    })
                    .WithErrorCode(DomainExceptions.InvalidPrivilege.Code)
                    .WithMessage(DomainExceptions.InvalidPrivilege.Message);
            });
        }
    }
}
