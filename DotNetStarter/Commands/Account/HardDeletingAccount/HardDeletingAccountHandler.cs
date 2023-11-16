using DotNetStarter.Commands.Talents.Delete;
using DotNetStarter.Commands.Users.Delete;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;

namespace DotNetStarter.Commands.Account.HardDeletingAccount
{
    internal class HardDeletingAccountHandler : BaseRequestHandler<HardDeletingAccount>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public HardDeletingAccountHandler(IDotNetStarterUnitOfWork unitOfWork, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Process(HardDeletingAccount request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindAsync(
                includeProperties: ClassUtils.GetPropertyName<User>(u => u.Role!),
                filter: u => u.Id == request.UserId && u.Status == Status.Deleting 
            );

            // Users active their account before 30 days
            if (user is null)
            {
                return;
            }
            
            if (user.Role!.Name is RoleNames.Talent)
            {
                new DeleteTalent(user.Id).Enqueue();
            }

            if (DomainConstraints.StaffMemberRoleNames.Any(r => r == user.Role!.Name))
            {
                new DeleteUser(new List<string> { user.Role!.Name }, user.Id).Enqueue();
            }
        }
    }
}
