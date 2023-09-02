using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Queries.Users.Get
{
    public sealed class GetUser : IRequest<User>
    {
        public Guid UserId { get; }

        public GetUser(Guid userId)
        {
            UserId = userId;
        }
    }
}
