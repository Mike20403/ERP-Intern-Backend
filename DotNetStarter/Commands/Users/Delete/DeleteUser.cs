using MediatR;

namespace DotNetStarter.Commands.Users.Delete
{
    public sealed class DeleteUser : IRequest
    {
        public Guid UserId { get; }

        public List<string> RoleNames { get; }

        public DeleteUser(List<string> roleNames, Guid userId)
        {
            UserId = userId;
            RoleNames = roleNames;
        }
    }
}
