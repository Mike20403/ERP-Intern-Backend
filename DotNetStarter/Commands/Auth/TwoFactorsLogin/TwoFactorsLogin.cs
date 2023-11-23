using DotNetStarter.Commands.Auth.Login;
using MediatR;

namespace DotNetStarter.Commands.Auth.TwoFactorsLogin
{
    public sealed class TwoFactorsLogin : IRequest<LoginResponse>
    {
        public Guid UserId { get; }

        public string TwoFactorsCode { get; }

        public TwoFactorsLogin
        (
            Guid userId,
            string twoFactorsCode
        )
        {
            UserId = userId;
            TwoFactorsCode = twoFactorsCode;
        }
    }
}
