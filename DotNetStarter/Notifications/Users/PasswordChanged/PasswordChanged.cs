using MediatR;

namespace DotNetStarter.Notifications.Users.PasswordChanged
{
    public sealed class PasswordChanged : INotification
    {
        public string Username { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public PasswordChanged(string username, string firstname, string lastname)
        {
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
