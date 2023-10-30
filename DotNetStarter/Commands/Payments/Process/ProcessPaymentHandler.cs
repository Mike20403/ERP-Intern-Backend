using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;

namespace DotNetStarter.Commands.Payments.Process
{
    public sealed class ProcessPaymentHandler : BaseRequestHandler<ProcessPayment>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ProcessPaymentHandler
        (
            IServiceProvider serviceProvider,
            IDotNetStarterUnitOfWork unitOfWork
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Process(ProcessPayment request, CancellationToken cancellationToken)
        {
            var payment = await _unitOfWork.PaymentRepository.GetByIdAsync(request.PaymentId);
            payment!.PaymentStatus = request.IsAccepted  ? PaymentStatus.Accepted : PaymentStatus.Rejected;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
