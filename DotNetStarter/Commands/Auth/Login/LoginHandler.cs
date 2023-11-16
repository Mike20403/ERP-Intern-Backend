using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Token;

namespace DotNetStarter.Commands.Auth.Login
{
    public sealed class LoginHandler : BaseRequestHandler<Login, LoginResponse>
    {
        private readonly ITokenService _tokenService;

        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public LoginHandler(IServiceProvider serviceProvider, ITokenService tokenService, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
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
