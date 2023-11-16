using MediatR;

namespace DotNetStarter.Notifications.Users.RecoveringAccountRequested
{
    public sealed class RecoveringAccountRequested : INotification
    {
        public string Email { get; }

        public string Firstname { get; }

        public string Code { get; }

        public RecoveringAccountRequested
        (
            string email,
            string firstname,
            string code
        ) 
        { 
            Email = email;
            Code = code;
            Firstname = firstname;
        }
    }
}
