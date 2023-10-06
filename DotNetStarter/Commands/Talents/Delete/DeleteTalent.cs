using MediatR;

namespace DotNetStarter.Commands.Talents.Delete
{
    public sealed class DeleteTalent: IRequest
    {
        public Guid UserId { get; }

        public DeleteTalent(Guid userId)
        {
            UserId = userId;
        }
    }
}
