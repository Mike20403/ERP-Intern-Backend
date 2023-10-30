using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Cards.AddOwner
{
    public sealed class AddOwnerHandler : BaseRequestHandler<AddOwner, DataChanged<Card>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public AddOwnerHandler(
            IDotNetStarterUnitOfWork unitOfWork,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<DataChanged<Card>> Process(AddOwner request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.CardRepository.FindAsync(ClassUtils.GetPropertyName<Card>(t => t.Owners!), filter: o => o.Id == request.CardId);
            var owner = await _unitOfWork.TalentRepository.GetByIdAsync(request.OwnerId);

            card!.Owners!.Add(owner!);
            await _unitOfWork.SaveChangesAsync();

            return new DataChanged<Card>(DataChangedType.Updated, card!);
        }
    }
}
