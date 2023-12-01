using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Stages.UpdateNotification
{
    public sealed class UpdateNotificationHandler : BaseRequestHandler<UpdateNotification>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public UpdateNotificationHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task Process(UpdateNotification request, CancellationToken cancellationToken)
        {
            var stage = await _unitOfWork.StageRepository.FindAsync(
                includeProperties: ClassUtils.GetPropertyName<Stage>(s => s.Users!),
                filter: s => s.Id == request.StageId);

            var user = await _unitOfWork.UserRepository.FindAsync(filter: u=> u.Id == request.ProjectManagerId || u.Id == request.TalentId);

            if (request.IsNotificationEnabled && !stage.Users!.Any(u => u.Id == user.Id))
            {
                stage.Users!.Add(user);
            }
            else if (!request.IsNotificationEnabled)
            {
                stage.Users!.Remove(user);
            }
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
