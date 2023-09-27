using MediatR;

namespace DotNetStarter.Commands.Account.ChangeEmailRequires
{
    public sealed class RequestChangeEmail : IRequest
    {
        public Guid UserId { get; }

        public string NewEmail { get; }
        
        public RequestChangeEmail(Guid userId, string NewEmail) {
            this.UserId = userId;
            this.NewEmail = NewEmail;
        }
    }
}
