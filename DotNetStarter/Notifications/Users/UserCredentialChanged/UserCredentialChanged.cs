using MediatR;

namespace DotNetStarter.Notifications.Users.UserCredentialChanged
{
    public class UserCredentialChanged : INotification
    {
        public Guid UserId { get; set; }

        public UserCredentialChanged(Guid userId)
        {
            UserId = userId;
        }
    }
}
