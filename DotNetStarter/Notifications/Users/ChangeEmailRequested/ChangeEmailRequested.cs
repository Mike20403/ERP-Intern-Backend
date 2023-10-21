using MediatR;

namespace DotNetStarter.Notifications.Users.ChangeEmailRequested
{
    public sealed class ChangeEmailRequested : INotification
    {
        public string Email { get; }

        public string NewEmail { get; }

        public string Firstname { get; }

        public string Code { get; }

        public ChangeEmailRequested(string email, string newEmail, string firstname, string code)
        {
            Email = email;
            NewEmail = newEmail;
            Firstname = firstname;
            Code = code;
        }
    }
}
