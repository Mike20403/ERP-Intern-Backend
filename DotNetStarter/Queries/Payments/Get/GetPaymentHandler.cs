using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Queries.Users.Get;

namespace DotNetStarter.Queries.Payments.Get
{
    public class GetPaymentHandler : BaseRequestHandler<GetPayment, Payment>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public GetPaymentHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Payment> Process(GetPayment request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.PaymentRepository
                    .FindAsync 
                    (
                        includeProperties:
                            $"{ClassUtils.GetPropertyName<Payment>(u => u.Talent)}," +
                            $"{ClassUtils.GetPropertyName<Payment>(u => u.Project)}," +
                            $"{ClassUtils.GetPropertyName<Payment>(u => u.Cards!)}.{ClassUtils.GetPropertyName<Card>(u => u.Stage!)}", 
                        filter: u => u.Id == request.PaymentId
                    );
        }
    }
}
