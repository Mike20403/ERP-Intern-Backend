using DotNetStarter.Commands.Auth.Login;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Token;

namespace DotNetStarter.Commands.Auth.RefreshToken
{
    public sealed class RefreshTokenHandler : BaseRequestHandler<RefreshToken, LoginResponse>
    {
        private readonly ITokenService _tokenService;

        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public RefreshTokenHandler(IServiceProvider serviceProvider, ITokenService tokenService, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }

        public override async Task<LoginResponse> Process(RefreshToken request, CancellationToken cancellationToken)
        {
            var existingAuthToken = await _unitOfWork.AuthTokenRepository.FindAsync(filter: rt => rt.Secret == request.Secret && rt.TokenId == request.TokenId && rt.UserId == request.UserId);
            var user = await _unitOfWork.UserRepository.FindAsync($"{ClassUtils.GetPropertyName<User>(u => u.Role)},{ClassUtils.GetPropertyName<User>(u => u.Privileges)}", u => u.Id == existingAuthToken!.UserId);

            var (token, authToken) = _tokenService.CreateToken(user!);

            existingAuthToken!.IsUsed = true;
            await _unitOfWork.AuthTokenRepository.UpdateAsync(existingAuthToken);

            await _unitOfWork.AuthTokenRepository.CreateAsync(authToken);
            await _unitOfWork.SaveChangesAsync();

            return new LoginResponse(token, authToken.Secret);
        }
    }
}