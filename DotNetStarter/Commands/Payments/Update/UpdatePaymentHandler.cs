using AutoMapper;
using DotNetStarter.Commands.Payments.Update;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Payments.Create
{
    public sealed class UpdatePaymentHandler : BaseRequestHandler<UpdatePayment, Payment>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UpdatePaymentHandler
        (
            IServiceProvider serviceProvider,
            IDotNetStarterUnitOfWork unitOfWork,
            IMapper mapper
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<Payment> Process(UpdatePayment request, CancellationToken cancellationToken)
        {
            var payment = await _unitOfWork.PaymentRepository.FindAsync
            (
                ClassUtils.GetPropertyName<Payment>(c => c.Cards!),
                filter: p => p.Id == request.PaymentId
            );
            payment!.Cards = await _unitOfWork.CardRepository.ListAsync(filter: c => request.CardIds!.Contains(c.Id));

            _mapper.Map(request, payment);

            await _unitOfWork.PaymentRepository.UpdateAsync(payment);
            await _unitOfWork.SaveChangesAsync();

            return payment;
        }
    }
}