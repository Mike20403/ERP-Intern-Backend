using DotNetStarter.Common.Enums;

namespace Api.Models.Payments
{
    public class ListPaymentsQueryParams : ListQueryParams
    {
        public PaymentStatus? Status { get; set; }
    }
}
