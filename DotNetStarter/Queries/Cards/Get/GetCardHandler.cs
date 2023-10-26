using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Cards.Get
{
    public sealed class GetCardHandler : BaseRequestHandler<GetCard, Card>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public GetCardHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task<Card> Process(GetCard request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CardRepository.FindAsync(
                includeProperties: ClassUtils.GetPropertyName<Card>(c => c.Attachments!),
                filter: c => c.Id == request.CardId
            );
        }
    }
}
