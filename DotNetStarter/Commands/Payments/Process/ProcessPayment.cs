using MediatR;

namespace DotNetStarter.Commands.Payments.Process
{
    public sealed class ProcessPayment : IRequest
    {
        public Guid AgencyMemberId { get; set; }

        public Guid ProjectId { get; }

        public Guid PaymentId { get; }

        public bool IsAccepted { get; }

        public ProcessPayment
        (
            Guid paymentId,
            Guid projectId,
            Guid agencyMember,
            bool isAccepted
        )
        {
            IsAccepted = isAccepted;
            ProjectId = projectId;
            PaymentId = paymentId;
            AgencyMemberId = agencyMember;
        }
    }
}
