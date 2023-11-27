using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.UserCredentialChanged;
using DotNetStarter.Services.Configuration;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Options;

namespace DotNetStarter.Commands.Account.Enable2fa
{
    public sealed class Enable2faHandler : BaseRequestHandler<Enable2fa, Enable2faResponse>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly AppSettings _appSettings;

        public Enable2faHandler
        (
            IDotNetStarterUnitOfWork unitOfWork,
            IOptions<AppSettings> appSettings,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        { 
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        public override async Task<Enable2faResponse> Process(Enable2fa request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);
            user!.is2faEnabled = true;

            var (from, to) = (1, _appSettings.Totp.TotpBackupCodeQuantity);

            var backupCodes = Enumerable
                .Range(from, to)
                .Select
                (
                    c => new TwoFactorsBackup
                    {
                        Id = Guid.NewGuid(),
                        UserId = request.UserId,
                        Code = string.Empty.GenerateCode(_appSettings.Totp.TotpBackupCodeLength),
                        IsUsed = false
                    }
                );

            await _unitOfWork.TwoFactorsBackupRepository.CreatesAsync(backupCodes.ToArray());

            await _unitOfWork.SaveChangesAsync();

            new UserCredentialChanged(user.Id).Enqueue();

            return new Enable2faResponse(backupCodes.Select(c => c.Code).ToList()!);
        }
    }
}
