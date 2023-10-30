using DotNetStarter.Common.Enums;

namespace Api.Dtos
{
    public class PaymentDto
    {
        public Guid? Id { get; set; }

        public string? ProjectName { get; set; }

        public string? Description { get; set; }

        public PersonDto? Talent { get; set; }

        public PaymentStatus? PaymentStatus { get; set; }

        public List<PaymentCardDto>? Cards { get; set; }

        public double? Amount { get; set; }
    }
}
