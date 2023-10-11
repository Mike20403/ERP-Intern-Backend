using DotNetStarter.Database.UnitOfWork;
using MediatR;

namespace DotNetStarter.Notifications.Users.UserCredentialChanged
{
    public class RevokeRefreshTokenHandler : INotificationHandler<UserCredentialChanged>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        public RevokeRefreshTokenHandler(IDotNetStarterUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UserCredentialChanged notification, CancellationToken cancellationToken)
        {
            var currentRefreshTokens = await _unitOfWork.AuthTokenRepository.ListAsync(filter: u => u.UserId == notification.UserId);
            currentRefreshTokens.ForEach(t => t.IsUsed = true);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
