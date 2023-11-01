using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Notifications.Cards.CardsMoved;
using DotNetStarter.Services.Email;
using MediatR;

public sealed class CardsMovedHandler : INotificationHandler<CardsMoved>
{
    private readonly IDotNetStarterUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;

    public CardsMovedHandler(IDotNetStarterUnitOfWork unitOfWork, IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _emailService = emailService;
    }

    public async Task Handle(CardsMoved notification, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.ProjectRepository.FindAsync(
            $"{ClassUtils.GetPropertyName<Project>(c => c.ProjectManager)},{ClassUtils.GetPropertyName<Project>(c => c.Stages)}",
            p => p.Id == notification.ProjectId);

        var projectManager = project!.ProjectManager;

        var changingStageCards = new List<ChangingCard>();

        foreach (var card in notification.NewCards)
        {
            var sourceStageId = notification.OldCards.First(c => c.Id == card.Id).StageId;
            var destinationStageId = card.StageId;
            if (sourceStageId != destinationStageId)
            {
                changingStageCards.Add(card);
            }
        }

        var groupedCards = changingStageCards.GroupBy(c => c.StageId);
        var hasNotificationGroupedCards = groupedCards.Where(group => project.Stages.Find(s => s.Id == group.Key).IsNotificationEnabled);

        foreach (var group in hasNotificationGroupedCards)
        {
            var stage = project.Stages.Find(s => s.Id == group.Key);
            await _emailService.SendCardMovedAsync(projectManager.Username, projectManager.Firstname, stage.Name, string.Join(", ", group.Select(c => c.Name)));
        }
    }
}
