using MediatR;

namespace DotNetStarter.Notifications.Users.ResetPasswordRequested
{
    public sealed class ResetPasswordRequested : INotification
    {
        public string Username { get; }

        public string Firstname { get; }

        public string Code { get; }

        public ResetPasswordRequested(string username, string firstname, string code)
        {
            Username = username;
            Firstname = firstname;
            Code = code;
        }
    }
}
