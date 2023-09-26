using MediatR;

namespace DotNetStarter.Commands.Account.ChangeEmailRequires
{
    public sealed class RequestChangeEmail : IRequest
    {
        public string Username { get; }

        public string NewEmail { get; }
        
        public RequestChangeEmail(string username, string NewEmail) {
            this.Username = username;
            this.NewEmail = NewEmail;
        }
    }
}
