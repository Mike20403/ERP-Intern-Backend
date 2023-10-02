using MediatR;

namespace DotNetStarter.Commands.Account.ChangeEmailRequires
{
    public sealed class RequestChangeEmail : IRequest
    {
        public Guid UserId { get; }

        public string Email { get; }
        
        public RequestChangeEmail(Guid userId, string email) {
            UserId = userId;
            Email = email;
        }
    }
}
