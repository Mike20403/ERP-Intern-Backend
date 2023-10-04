using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Queries.Users.Get
{
    public sealed class GetUser : IRequest<User>
    {
        public List<string>? RoleNames { get; }

        public Guid UserId { get; }

        public GetUser(List<string>? roleNames, Guid userId)
        {
            RoleNames = roleNames;
            UserId = userId;
        }
    }
}
