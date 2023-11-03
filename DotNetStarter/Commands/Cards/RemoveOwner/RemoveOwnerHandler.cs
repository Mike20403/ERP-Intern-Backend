using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Cards.RemoveOwner
{
    public sealed class RemoveOwnerHandler : BaseRequestHandler<RemoveOwner, DataChanged<Talent>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public RemoveOwnerHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<DataChanged<Talent>> Process(RemoveOwner request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.CardRepository.FindAsync(ClassUtils.GetPropertyName<Card>(t => t.Owners!), filter: o => o.Id == request.CardId);
            var owner = await _unitOfWork.TalentRepository.GetByIdAsync(request.OwnerId);

            card!.Owners!.Remove(owner!);
            await _unitOfWork.SaveChangesAsync();

            return new DataChanged<Talent>(DataChangedType.Deleted, owner!);
        }
    }
}
