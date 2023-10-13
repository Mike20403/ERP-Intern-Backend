using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;

namespace DotNetStarter.Commands.Cards.MoveCards
{
    public sealed class MoveCardsHandler : BaseRequestHandler<MoveCards, List<DataChanged<MovingCard>>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public MoveCardsHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IMapper mapper) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<List<DataChanged<MovingCard>>> Process(MoveCards request, CancellationToken cancellationToken)
        {
            var cardIds = request.Cards.Select(c => c.Id).ToList();

            var existingCards = await _unitOfWork.CardRepository.ListAsync(filter: c => cardIds.Contains(c.Id));

            existingCards.ForEach(card =>
            {
                var updatingCard = request.Cards.First(c => c.Id == card.Id);
                _mapper.Map(updatingCard, card);
            });

            await _unitOfWork.SaveChangesAsync();

            return existingCards.Select(c => new DataChanged<MovingCard>(DataChangedType.Updated, _mapper.Map<MovingCard>(c))).ToList();
        }
    }
}
