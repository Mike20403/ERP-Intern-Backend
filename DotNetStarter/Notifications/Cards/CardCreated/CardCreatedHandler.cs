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
        var stage = await _unitOfWork.StageRepository.FindAsync(ClassUtils.GetPropertyName<Stage>(t => t.Users!), filter: o => o.Id == notification.StageId);

        if (stage is null || stage.Users is null)
        {
            return;
        }

        var users = stage!.Users!.ToList();
        var recipients = users.Select(user => new CardRecipient
        {
            Email = user.Username,
            FirstName = user.Firstname,
            StageName = stage.Name,
            CardName = card.Name
        }).ToList();

        await _emailService.SendCardCreatedAsync(recipients);
    }
}

