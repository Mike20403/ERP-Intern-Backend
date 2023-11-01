using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Notifications.Cards.CardCreated;
using DotNetStarter.Services.Email;
using MediatR;

public sealed class CardCreatedHandler : INotificationHandler<CardCreated>
{
    private readonly IDotNetStarterUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;

    public CardCreatedHandler(IDotNetStarterUnitOfWork unitOfWork, IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _emailService = emailService;
    }

    public async Task Handle(CardCreated notification, CancellationToken cancellationToken)
    {
        var card = await _unitOfWork.CardRepository.GetByIdAsync(notification.CardId);
        var stage = await _unitOfWork.StageRepository.GetByIdAsync(notification.StageId);

        if (card is null || stage is null || !stage.IsNotificationEnabled)
        {
            return;
        }
        var project = await _unitOfWork.ProjectRepository.FindAsync($"{ClassUtils.GetPropertyName<Project>(c => c.ProjectManager)}", p => p.Id == notification.ProjectId);
        var projectManager = project!.ProjectManager;
        await _emailService.SendCardCreatedAsync(projectManager.Username, projectManager.Firstname, stage.Name, card.Name);
    }
}

