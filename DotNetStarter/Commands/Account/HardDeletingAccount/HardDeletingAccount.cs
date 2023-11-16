using MediatR;

namespace DotNetStarter.Commands.Account.HardDeletingAccount
{
    public sealed class HardDeletingAccount : IRequest
    {
        public Guid UserId { get; }

        public HardDeletingAccount(Guid userId)
        {
            UserId = userId;
        }
    }
}
