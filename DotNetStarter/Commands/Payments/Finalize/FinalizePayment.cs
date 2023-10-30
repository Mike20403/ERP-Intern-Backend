using MediatR;

namespace DotNetStarter.Commands.Payments.Finalize
{
    public sealed class FinalizePayment : IRequest
    {
        public Guid ProjectManagerId { get; }

        public Guid ProjectId { get; }

        public Guid PaymentId { get; }

        public FinalizePayment(Guid paymentId, Guid projectId, Guid projectManagerId) {
            ProjectManagerId = projectManagerId;
            ProjectId = projectId;
            PaymentId = paymentId;
        }
    }
}
