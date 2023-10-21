using MediatR;

namespace DotNetStarter.Notifications.Users.UserCredentialChanged
{
    public sealed class UserCredentialChanged : INotification
    {
        public Guid UserId { get; }

        public UserCredentialChanged(Guid userId)
        {
            UserId = userId;
        }
    }
}
