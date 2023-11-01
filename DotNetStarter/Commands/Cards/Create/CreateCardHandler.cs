using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Cards.CardCreated;

namespace DotNetStarter.Commands.Cards.Create
{
    public sealed class CreateCardHandler : BaseRequestHandler<CreateCard, List<DataChanged<Card>>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCardHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IMapper mapper) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<List<DataChanged<Card>>> Process(CreateCard request, CancellationToken cancellationToken)
        {
            var card = _mapper.Map<Card>(request);

            var cards = new List<DataChanged<Card>> { new DataChanged<Card>(DataChangedType.Created, card) };

            await _unitOfWork.CardRepository.CreateAsync(card);

            if (request.PrevCardId.HasValue)
            {
                var prevCard = await _unitOfWork.CardRepository.GetByIdAsync(request.PrevCardId.Value);
                if (prevCard != null)
                {
                    prevCard.NextCardId = card.Id;
                    cards.Add(new DataChanged<Card>(DataChangedType.Updated, prevCard));
                }
            }

            if (request.NextCardId.HasValue)
            {
                var nextCard = await _unitOfWork.CardRepository.GetByIdAsync(request.NextCardId.Value);
                if (nextCard != null)
                {
                    nextCard.PrevCardId = card.Id;
                    cards.Add(new DataChanged<Card>(DataChangedType.Updated, nextCard));
                }
            }

            await _unitOfWork.SaveChangesAsync();

            new CardCreated(card.Id, request.ProjectId, request.StageId).Enqueue();

            return cards;
        }
    }
}

