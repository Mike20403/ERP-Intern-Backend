using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Payments.Create
{
    public sealed class CreatePayment : IRequest<Payment>
    {
        public Guid TalentId { get; }

        public Guid ProjectId { get; }

        public List<Guid> CardIds { get; }

        public string? Description { get; }

        public double Amount { get; }

        public CreatePayment(Guid talentId, Guid projectId, List<Guid> cardIds, string? description, double amount) {
            TalentId = talentId;
            ProjectId = projectId;
            CardIds = cardIds;
            Description = description;
            Amount = amount;
        }
    }
}
