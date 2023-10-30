using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;

namespace DotNetStarter.Commands.Payments.Finalize
{
    public sealed class FinalizePaymentHandler : BaseRequestHandler<FinalizePayment>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public FinalizePaymentHandler
        (
            IServiceProvider serviceProvider,
            IDotNetStarterUnitOfWork unitOfWork
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Process(FinalizePayment request, CancellationToken cancellationToken)
        {
            var payment = await _unitOfWork.PaymentRepository.GetByIdAsync(request.PaymentId);
            payment!.PaymentStatus = PaymentStatus.Finalized;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
