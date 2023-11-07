using MediatR;

namespace DotNetStarter.Commands.Users.ResetPassword
{
    public sealed class ResetPassword : IRequest
    {
        public List<string> RoleNames { get; }

        public Guid UserId { get; }

        public ResetPassword(List<string> roleNames, Guid userId)
        {
            RoleNames = roleNames;
            UserId = userId;
        }
    }
}
