using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;

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
            await _unitOfWork.TalentRepository.DeleteAsync(request.UserId);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
