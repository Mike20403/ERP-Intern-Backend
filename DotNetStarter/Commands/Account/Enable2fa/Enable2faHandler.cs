using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.UserCredentialChanged;

namespace DotNetStarter.Commands.Account.Enable2fa
{
    public sealed class Enable2faHandler : BaseRequestHandler<Enable2fa>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public Enable2faHandler
        (
            IDotNetStarterUnitOfWork unitOfWork,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        { 
            _unitOfWork = unitOfWork;
        }

        public override async Task Process(Enable2fa request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);

            user!.is2faEnabled = true;

            await _unitOfWork.SaveChangesAsync();

            new UserCredentialChanged(user.Id).Enqueue();
        }
    }
}
