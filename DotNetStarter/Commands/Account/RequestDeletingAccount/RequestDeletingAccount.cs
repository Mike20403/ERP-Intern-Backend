using MediatR;

namespace DotNetStarter.Commands.Account.RequestDeletingAccount
{
    public sealed class RequestDeletingAccount : IRequest
    {
        public Guid UserId { get; }

        public RequestDeletingAccount(Guid userId) {
            UserId = userId;
        }
    }
}
