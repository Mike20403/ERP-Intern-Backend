using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using FluentValidation;
using System.Linq.Expressions;

namespace DotNetStarter.Commands.Invitations.InviteTalents
{
    public sealed class InviteTalentsValidator : AbstractValidator<InviteTalents>
    {
        public InviteTalentsValidator(IDotNetStarterUnitOfWork unitOfWork)
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
                .MustAsync((inviterRole, cancellation) => unitOfWork.RoleRepository.AnyAsync(filter: r => r.Name == inviterRole))
                .WithErrorCode(DomainExceptions.InvalidRoleName.Code)
                .WithMessage(DomainExceptions.InvalidRoleName.Message);

            RuleForEach(x => x.Talents).SetValidator(request => new InviteTalentValidator(unitOfWork));

            When(x => x.InviterRole is not null, () =>
            {
                RuleFor(x => x.InviterId)
                    .MustAsync(async (request, inviterId, cancellation) =>
                    {
                        var filter = new List<Expression<Func<Project, bool>>>() { p => p.Id == request.ProjectId };

                        if (request.InviterRole == RoleNames.AgencyMember)
                        {
                            filter.Add(u => u.AgencyMemberId == request.InviterId);
                        }

                        if (request.InviterRole == RoleNames.ProjectManager)
                        {
                            filter.Add(u => u.ProjectManagerId == request.InviterId);
                        }

                        return await unitOfWork.ProjectRepository.AnyAsync(filter.ToArray());
                    })
                    .WithErrorCode(DomainExceptions.InvalidPrivilege.Code)
                    .WithMessage(DomainExceptions.InvalidPrivilege.Message);

                When(x => x.InviterRole is RoleNames.ProjectManager, () =>
                {
                    RuleFor(x => x.Talents)
                        .Must(talents => talents.Count == talents.Where(i => i.Id is not null).Count())
                        .WithErrorCode(DomainExceptions.InvalidPrivilege.Code)
                        .WithMessage(DomainExceptions.InvalidPrivilege.Message);
                });
            });
        }
    }
}
