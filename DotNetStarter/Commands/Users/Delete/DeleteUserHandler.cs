using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using System.Linq.Expressions;

namespace DotNetStarter.Commands.Users.Delete
{
    public sealed class DeleteUserHandler : BaseRequestHandler<DeleteUser>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public DeleteUserHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Process(DeleteUser request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindAsync(
                includeProperties: ClassUtils.GetPropertyName<User>(u => u.Role!),
                filter: u => u.Id == request.UserId
            );

            var invitations = await _unitOfWork.InvitationRepository.ListAsync(filter: i => i.InviterId == user!.Id);

            if (user!.Role!.Name is RoleNames.AgencyMember)
            {
                var projects = await _unitOfWork.ProjectRepository.ListAsync
                (
                    includeProperties: ClassUtils.GetPropertyName<Project>(p => p.Talents!),
                    filter: p => p.AgencyMemberId == user.Id
                );

                var cards = await _unitOfWork.CardRepository.ListAsync
                (
                    includeProperties: ClassUtils.GetPropertyName<Card>(c => c.Owners!),
                    filter: c => projects.Contains(c.Stage!.Project!)
                );

                cards.ForEach(c => c.Owners = null);
                projects.ForEach(p => p.Talents = null);
                await _unitOfWork.ProjectRepository.DeletesAsync(projects.ToArray());
            }

            if (user!.Role!.Name is RoleNames.ProjectManager)
            {
                await _unitOfWork.ProjectRepository.BulkUpdateAsync
                (
                    p => p.ProjectManagerId == user.Id,                    // Condition
                    s => s.SetProperty(p => p.ProjectManagerId, p => null) // update statement
                );
            }

            await _unitOfWork.InvitationRepository.DeletesAsync(invitations.ToArray());
            await _unitOfWork.UserRepository.DeleteAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
