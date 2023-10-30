using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Payments.Create
{
    public sealed class CreatePaymentHandler : BaseRequestHandler<CreatePayment, Payment>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CreatePaymentHandler
        (
            IServiceProvider serviceProvider,
            IDotNetStarterUnitOfWork unitOfWork,
            IMapper mapper
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<Payment> Process(CreatePayment request, CancellationToken cancellationToken)
        {
            var cards = await _unitOfWork.CardRepository.ListAsync(
                includeProperties: ClassUtils.GetPropertyName<Card>(c => c.Stage!), 
                filter: c => request.CardIds.Contains(c.Id)
            );

            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.ProjectId);
            var talent = await _unitOfWork.TalentRepository.GetByIdAsync(request.TalentId);

            var payment = new Payment()
            {
                PaymentStatus = PaymentStatus.Draft,
                Cards = cards,
                Project = project,
                Talent = talent
            };

            _mapper.Map(request, payment);
            await _unitOfWork.PaymentRepository.CreateAsync(payment);
            await _unitOfWork.SaveChangesAsync();

            return payment!;
        }
    }
}