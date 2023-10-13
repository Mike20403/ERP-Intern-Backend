using MediatR;

namespace DotNetStarter.Commands.Cards.MoveCards
{
    public sealed class MovingCard
    {
        public Guid Id { get; set; }

        public Guid? PrevCardId { get; set; }

        public Guid? NextCardId { get; set; }

        public Guid StageId { get; set; }

        public MovingCard(Guid id, Guid? prevCardId, Guid? nextCardId, Guid stageId)
        {
            Id = id;
            PrevCardId = prevCardId;
            NextCardId = nextCardId;
            StageId = stageId;
        }
    }
}
