using DotNetStarter.Commands.Auth.Login;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Token;

namespace DotNetStarter.Commands.Auth.LoginWithBackup
{
    public sealed class LoginWithBackupHandler : BaseRequestHandler<LoginWithBackup, LoginResponse>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly ITokenService _tokenService;

        public LoginWithBackupHandler
        (
            IDotNetStarterUnitOfWork unitOfWork,
            ITokenService tokenService,
            IServiceProvider serviceProvider
        ) : base (serviceProvider)
        { 
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public override async Task<LoginResponse> Process(LoginWithBackup request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository
                .FindAsync($"{ClassUtils.GetPropertyName<User>(u => u.Role!)},{ClassUtils.GetPropertyName<User>(u => u.Privileges)}", u => u.Username == request.Username);

            var (token, authToken) = _tokenService.CreateToken(user!, TokenTypeNames.Access);

            (await _unitOfWork.TwoFactorsBackupRepository.FindAsync(filter: c => c.Code == request.BackupCode))!.IsUsed = true;

            if (authToken is not null)
            {
                await _unitOfWork.AuthTokenRepository.CreateAsync(authToken);
                await _unitOfWork.SaveChangesAsync();
            }

            return new LoginResponse(token, authToken?.Secret);
        }
    }
}
