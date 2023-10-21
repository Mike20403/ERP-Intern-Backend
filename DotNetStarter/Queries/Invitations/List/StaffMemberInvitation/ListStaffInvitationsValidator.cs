using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using FluentValidation;
using System.Linq.Expressions;

namespace DotNetStarter.Queries.Invitations.List.StaffMemberInvitation
{
    public sealed class ListStaffInvitationsValidator : AbstractValidator<ListStaffInvitations>
    {
        public ListStaffInvitationsValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .MustAsync((projectId, cancellation) => unitOfWork.ProjectRepository.AnyAsync(u => u.Id == projectId))
                .WithErrorCode(DomainExceptions.ProjectNotFound.Code)
                .WithMessage(DomainExceptions.ProjectNotFound.Message);

            RuleFor(x => x.StaffMemberId)
                .NotEmpty()
                .MustAsync((staffMemberId, cancellation) => unitOfWork.UserRepository.AnyAsync(filter: u => u.Id == staffMemberId))
                .WithErrorCode(DomainExceptions.UserNotFound.Code)
                .WithMessage(DomainExceptions.UserNotFound.Message);

            RuleFor(x => x.StaffMemberRole)
                .NotEmpty()
                .MustAsync((staffMemberRole, cancellation) => unitOfWork.RoleRepository.AnyAsync(filter: r => r.Name == staffMemberRole))
                .WithErrorCode(DomainExceptions.InvalidRoleName.Code)
                .WithMessage(DomainExceptions.InvalidRoleName.Message);

            When(x => x.StaffMemberRole is not null, () =>
            {
                RuleFor(x => x.StaffMemberId)
                    .MustAsync(async (request, staffMemberId, cancellation) =>
                    {
                        var filter = new List<Expression<Func<Project, bool>>>() { p => p.Id == request.ProjectId };

                        if (request.StaffMemberRole == RoleNames.AgencyMember)
                        {
                            filter.Add(u => u.AgencyMemberId == staffMemberId);
                        }

                        if (request.StaffMemberRole == RoleNames.ProjectManager)
                        {
                            filter.Add(u => u.ProjectManagerId == staffMemberId);
                        }

                        return await unitOfWork.ProjectRepository.AnyAsync(filter.ToArray());
                    })
                    .WithErrorCode(DomainExceptions.InvalidPrivilege.Code)
                    .WithMessage(DomainExceptions.InvalidPrivilege.Message);
            });
        }
    }
}
