using MediatR;

namespace DotNetStarter.Commands.Account.ConfirmChangeEmail
{
    public sealed class ConfirmChangeEmail : IRequest
    {
        public Guid UserId { get; }

        public string Email { get; }

        public string ActiveCode { get; }

        public ConfirmChangeEmail(Guid userId, string email, string activeCode)
        {
            UserId = userId;
            Email = email;
            ActiveCode = activeCode;
        }
    }
}