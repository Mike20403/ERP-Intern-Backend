using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.DeletingAccountRequested;
using DotNetStarter.Services.Configuration;
using Microsoft.Extensions.Options;

namespace DotNetStarter.Commands.Account.RequestDeletingAccount
{
    public sealed class RequestDeletingAccountHandler : BaseRequestHandler<RequestDeletingAccount>
    {

        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly AppSettings _appSettings;

        public RequestDeletingAccountHandler
        (
            IServiceProvider serviceProvider, 
            IDotNetStarterUnitOfWork unitOfWork,
            IOptions<AppSettings> appSettings
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        public override async Task Process(RequestDeletingAccount request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);
            user!.Status = Status.Deleting ;
            await _unitOfWork.SaveChangesAsync();

            new HardDeletingAccount.HardDeletingAccount(user!.Id).Schedule(_appSettings.Account.PermanentDeleteAccountDuration!);

            new DeletingAccountRequested(user.Username, user.Firstname).Enqueue();
        }
    }
}
