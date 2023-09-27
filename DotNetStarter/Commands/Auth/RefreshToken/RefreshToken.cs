using DotNetStarter.Commands.Auth.Login;
using MediatR;

namespace DotNetStarter.Commands.Auth.RefreshToken
{
    public sealed class RefreshToken : IRequest<LoginResponse>
    {
        public Guid UserId { get; }

        public Guid TokenId { get; }

        public string Secret { get; }

        public RefreshToken(Guid userId, Guid tokenId, string secret)
        {
            UserId = userId;
            TokenId = tokenId;
            Secret = secret;
        }
    }
}