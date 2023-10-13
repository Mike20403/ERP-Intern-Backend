using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Cards.Update
{
    public sealed class UpdateCardHandler : BaseRequestHandler<UpdateCard, DataChanged<Card>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UpdateCardHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IMapper mapper) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public override async Task<DataChanged<Card>> Process(UpdateCard request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.CardRepository.GetByIdAsync(request.CardId);


            _mapper.Map(request, card);

            var cards = new DataChanged<Card>(DataChangedType.Updated, card);

            await _unitOfWork.CardRepository.UpdateAsync(card!);
            await _unitOfWork.SaveChangesAsync();

            return cards!;
        }
    }
}
