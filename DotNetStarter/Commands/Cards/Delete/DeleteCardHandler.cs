using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Storage;

namespace DotNetStarter.Commands.Cards.Delete
{
    public sealed class DeleteCardHandler : BaseRequestHandler<DeleteCard, List<DataChanged<Card>>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        private readonly IStorageService _storageService;

        public DeleteCardHandler(
            IServiceProvider serviceProvider,
            IDotNetStarterUnitOfWork unitOfWork,
            IStorageService storageService)
            : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _storageService = storageService;
        }

        public override async Task<List<DataChanged<Card>>> Process(DeleteCard request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.CardRepository.FindAsync($"{ClassUtils.GetPropertyName<Card>(c => c.PrevCard)},{ClassUtils.GetPropertyName<Card>(c => c.NextCard)}", c => c.Id == request.CardId);

            var cards = new List<DataChanged<Card>> { new DataChanged<Card>(DataChangedType.Deleted, card) };

            if (card!.PrevCard is not null)
            {
                card!.PrevCard.NextCardId = card.NextCardId;
                cards.Add(new DataChanged<Card>(DataChangedType.Updated, card!.PrevCard));
            }

            if (card!.NextCard is not null)
            {
                card!.NextCard.PrevCardId = card.PrevCardId;
                cards.Add(new DataChanged<Card>(DataChangedType.Updated, card!.NextCard));
            }

            await _storageService.DeleteDirectoryAsync($"projects/{request.ProjectId}/cards/{request.CardId}");

            await _unitOfWork.CardRepository.DeleteAsync(request.CardId);
            await _unitOfWork.SaveChangesAsync();

            return cards;
        }
    }
}
