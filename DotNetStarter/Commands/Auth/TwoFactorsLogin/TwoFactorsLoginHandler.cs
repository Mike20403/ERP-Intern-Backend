using DotNetStarter.Commands.Auth.Login;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Configuration;
using DotNetStarter.Services.Token;
using Microsoft.Extensions.Options;
using OtpNet;

namespace DotNetStarter.Commands.Auth.TwoFactorsLogin
{
    public sealed class TwoFactorsLoginHandler : BaseRequestHandler<TwoFactorsLogin, LoginResponse>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly ITokenService _tokenService;

        private readonly AppSettings _appSettings;

        public TwoFactorsLoginHandler
        (
            IDotNetStarterUnitOfWork unitOfWork,
            ITokenService tokenService,
            IServiceProvider serviceProvider,
            IOptions<AppSettings> appSettings
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _appSettings = appSettings.Value;
        }

        public override async Task<LoginResponse> Process(TwoFactorsLogin request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository
                .FindAsync($"{ClassUtils.GetPropertyName<User>(u => u.Role!)},{ClassUtils.GetPropertyName<User>(u => u.Privileges)}", u => u.Id == request.UserId);
            
            var (token, authToken) = _tokenService.CreateToken(user!, TokenTypeNames.Access);

            if (authToken is not null)
            {
                await _unitOfWork.AuthTokenRepository.CreateAsync(authToken);
                await _unitOfWork.SaveChangesAsync();
            }

            return new LoginResponse(token, authToken?.Secret);
        }
    }
}
