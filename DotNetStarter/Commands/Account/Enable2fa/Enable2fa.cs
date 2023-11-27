using MediatR;

namespace DotNetStarter.Commands.Account.Enable2fa
{
    public sealed class Enable2fa : IRequest<Enable2faResponse>
    {
        public Guid UserId { get; }
        public string TwoFactorsCode { get; }

        public Enable2fa
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
