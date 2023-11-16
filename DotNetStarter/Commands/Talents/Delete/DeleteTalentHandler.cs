using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Talents.Delete
{
    public sealed class DeleteTalentHandler : BaseRequestHandler<DeleteTalent>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public DeleteTalentHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Process(DeleteTalent request, CancellationToken cancellationToken)
        {
            var talent = await _unitOfWork.UserRepository.FindAsync(filter: u => u.Id == request.UserId);
            var invitations = await _unitOfWork.InvitationRepository.ListAsync(filter: i => i.TalentId == talent!.Id);

            var payments = await _unitOfWork.PaymentRepository.ListAsync
            (
                includeProperties: ClassUtils.GetPropertyName<Payment>(p => p.Cards!),
                filter: p => p.TalentId == talent!.Id
            );
            var cards = await _unitOfWork.CardRepository.ListAsync
            (
                includeProperties: ClassUtils.GetPropertyName<Card>(c => c.Owners!),
                filter: c => c.Owners!.Any(o => o.Id == talent!.Id)
            );

            payments.ForEach(p => p.Cards = null); 
            cards.ForEach(c => c.Owners = null);
            await _unitOfWork.PaymentRepository.UpdatesAsync(payments.ToArray());
            await _unitOfWork.CardRepository.UpdatesAsync(cards.ToArray());

            await _unitOfWork.PaymentRepository.DeletesAsync(payments.ToArray());
            await _unitOfWork.InvitationRepository.DeletesAsync(invitations.ToArray());
            await _unitOfWork.UserRepository.DeleteAsync(talent!);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
