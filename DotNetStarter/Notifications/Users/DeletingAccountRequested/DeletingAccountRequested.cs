using MediatR;

namespace DotNetStarter.Notifications.Users.DeletingAccountRequested
{
    public sealed class DeletingAccountRequested : INotification
    {
        public string Email { get; }

        public string Firstname { get; }

        public DeletingAccountRequested
        (
            string email,
            string firstname
        ) 
        { 
            Email = email;
            Firstname = firstname;
        }
    }
}
