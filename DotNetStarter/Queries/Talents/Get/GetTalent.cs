using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Queries.Talents.Get
{
    public sealed class GetTalent : IRequest<Talent>
    {
        public Guid UserId { get; }

        public GetTalent(Guid userId)
        {
            UserId = userId;
        }
    }
}
