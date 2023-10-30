using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Payments.List
{
    public sealed class ListPayments : ListRequest<Payment>
    {
        public Guid? TalentId { get; }

        public Guid? StaffmemberId { get; }

        public Guid? ProjectId { get; }

        public PaymentStatus? PaymentStatus { get; }

        public ListPayments
        (
            Guid? talentId,
            Guid? staffmemberId,
            Guid? projectId,
            PaymentStatus? paymentStatus,
            int pageNumber,
            int pageSize,
            string? searchQuery,
            string? orderBy
        ) : base(pageNumber, pageSize, searchQuery, orderBy)
        {
            PaymentStatus = paymentStatus;
            ProjectId = projectId;
            TalentId = talentId;
            StaffmemberId = staffmemberId;
        }
    }
}
