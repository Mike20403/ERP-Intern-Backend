using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Configuration;
using DotNetStarter.Services.Token;
using Microsoft.Extensions.Options;
using OtpNet;

namespace DotNetStarter.Commands.Auth.Login
{
    public sealed class LoginHandler : BaseRequestHandler<Login, LoginResponse>
    {
        private readonly ITokenService _tokenService;

        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public LoginHandler
        (
            ITokenService tokenService, 
            IDotNetStarterUnitOfWork unitOfWork,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }

        public override async Task<LoginResponse> Process(Login request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindAsync($"{ClassUtils.GetPropertyName<User>(u => u.Role)},{ClassUtils.GetPropertyName<User>(u => u.Privileges)}", u => u.Username == request.Username);

            string tokenType = user!.Status switch
            {
                Status.Active => TokenTypeNames.Access,
                Status.ChangingPasswordRequired => TokenTypeNames.ForceChangePassword,
                Status.Deleting  => TokenTypeNames.Recover,
                _ => TokenTypeNames.Access,
            };

            string? totpCode = null;

            if (user!.is2faEnabled && user.Status is Status.Active)
            {
                tokenType = TokenTypeNames.TwoFactors;

                var totp = new Totp(Base32Encoding.ToBytes(user.Secret));

                totpCode = totp.ComputeTotp();
            }

            var (token, authToken) = _tokenService.CreateToken(user!, tokenType);

            if (authToken is not null)
            {
                await _unitOfWork.AuthTokenRepository.CreateAsync(authToken);
                await _unitOfWork.SaveChangesAsync();
            }
            
            return new LoginResponse(token, authToken?.Secret);
        }
    }
}
