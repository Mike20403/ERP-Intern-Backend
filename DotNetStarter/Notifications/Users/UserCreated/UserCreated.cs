using DotNetStarter.Common.Enums;
using MediatR;

namespace DotNetStarter.Notifications.Users.UserCreated
{
    public sealed class UserCreated : INotification
    {
        public Status Status { get; }

        public Guid UserId { get; }

        public string Username { get; }

        public string Firstname { get; }

        public UserCreated(Status status, Guid userId, string username, string firstname)
        {
            Status = status;
            UserId = userId;
            Username = username;
            Firstname = firstname;
        }
    }
}
