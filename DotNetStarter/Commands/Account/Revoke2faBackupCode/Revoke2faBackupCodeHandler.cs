using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;

namespace DotNetStarter.Commands.Account.Revoke2faBackupCode
{
    public sealed class Revoke2faBackupCodeHandler : BaseRequestHandler<Revoke2faBackupCode>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public Revoke2faBackupCodeHandler
        (
            IDotNetStarterUnitOfWork unitOfWork, 
            IServiceProvider serviceProvider
        ) : base (serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Process(Revoke2faBackupCode request, CancellationToken cancellationToken)
        {
            var backupCodes = await _unitOfWork.TwoFactorsBackupRepository.ListAsync(filter: tfc => tfc.UserId == request.UserId);

            await _unitOfWork.TwoFactorsBackupRepository.DeletesAsync(backupCodes.ToArray());

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
