using MediatR;

namespace DotNetStarter.Notifications.Users.ResetPasswordByAdminRequested
{
    public sealed class PasswordReset : INotification
    {
        public string Username { get; }

        public string Firstname { get; }

        public string Password { get; }

        public PasswordReset(string username, string firstname, string password)
        {
            Username = username;
            Firstname = firstname;
            Password = password;
        }
    }
}
