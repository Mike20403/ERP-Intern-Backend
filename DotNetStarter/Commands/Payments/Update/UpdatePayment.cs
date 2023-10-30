using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Payments.Update
{
    public sealed class UpdatePayment : IRequest<Payment>
    {
        public Guid TalentId { get; }

        public Guid ProjectId { get; }

        public Guid PaymentId { get; }

        public double Amount { get; }

        public string? Description { get; }

        public List<Guid> CardIds { get; }

        public UpdatePayment
        (
            Guid talentId, 
            Guid projectId,
            Guid paymentId,
            List<Guid> cardIds,
            string? description,
            double amount
        )
        {
            TalentId = talentId;
            ProjectId = projectId;
            CardIds = cardIds;
            Description = description;
            Amount = amount;
            PaymentId = paymentId;
        }
    }
}
