using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Queries.Talents.Get
{
    public class GetTalent : IRequest<Talent>
    {
        public Guid UserId { get; }

        public GetTalent(Guid userId)
        {
            UserId = userId;
        }
    }
}
