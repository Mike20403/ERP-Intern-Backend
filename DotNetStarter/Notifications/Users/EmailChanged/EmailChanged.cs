using MediatR;

namespace DotNetStarter.Notifications.Users.EmailChanged
{
    public sealed class EmailChanged : INotification
    {
        public string OldEmail { get; }

        public string Email { get; }

        public string Firstname { get; }

        public string Code { get; }

        public EmailChanged(string oldEmail, string email, string firstname, string code)
        {
            OldEmail = oldEmail;
            Email = email;
            Firstname = firstname;
            Code = code;
        }
    }
}
