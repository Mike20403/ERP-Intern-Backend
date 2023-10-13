using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Cards.List
{
    public sealed class ListCardsHandler : BaseRequestHandler<ListCards, List<Card>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ListCardsHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task<List<Card>> Process(ListCards request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CardRepository.ListAsync(filter: s => s.Stage.ProjectId == request.ProjectId);
        }
    }
}
