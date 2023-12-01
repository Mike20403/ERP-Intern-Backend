using MediatR;

namespace DotNetStarter.Commands.Stages.UpdateNotification
{
    public sealed class UpdateNotification : IRequest
    {
        public Guid? ProjectManagerId { get; }

        public Guid? TalentId { get; }

        public Guid ProjectId { get; }

        public Guid StageId { get; }

        public bool IsNotificationEnabled { get; }

        public UpdateNotification(Guid? projectManagerId, Guid? talentId, Guid projectId, Guid stageId, bool isNotificationEnabled)
        {
            ProjectManagerId = projectManagerId;
            TalentId = talentId;
            ProjectId = projectId;
            StageId = stageId;
            IsNotificationEnabled = isNotificationEnabled;
        }
    }
}
