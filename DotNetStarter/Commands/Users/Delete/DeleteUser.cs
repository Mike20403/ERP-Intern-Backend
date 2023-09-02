using MediatR;

namespace DotNetStarter.Commands.Users.Delete
{
    public sealed class DeleteUser : IRequest
    {
        public Guid UserId { get; }

        public DeleteUser(Guid userId)
        {
            UserId = userId;
        }
    }
}
