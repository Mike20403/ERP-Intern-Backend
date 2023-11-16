using MediatR;

namespace DotNetStarter.Commands.Account.RecoverAccount
{
    public sealed class RecoverAccount : IRequest
    {
        public Guid UserId { get; }
        public RecoverAccount(Guid userId) {
            UserId = userId;
        }
    }
}
