using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Queries.Payments.Get
{
    public sealed class GetPayment : IRequest<Payment>
    {
        public Guid UserId { get; }

        public Guid PaymentId { get; }

        public Guid ProjectId { get; }

        public GetPayment(Guid userId, Guid paymentId, Guid projectId)
        {
            UserId = userId;
            PaymentId = paymentId;
            ProjectId = projectId;
        }
    }
}
