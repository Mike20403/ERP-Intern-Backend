using MediatR;

namespace DotNetStarter.Commands.Account.Revoke2faBackupCode
{
    public sealed class Revoke2faBackupCode : IRequest
    {
        public Guid UserId { get; }

        public Revoke2faBackupCode(Guid userId)
        {
            UserId = userId;
        }
    }
}
