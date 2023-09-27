using MediatR;

namespace DotNetStarter.Commands.Account.ActivateEmail
{
    public sealed class ActivateEmail : IRequest
    {
        public string Email { get; }
        public string ActiveCode { get; }

        public ActivateEmail(string email, string activateCode)
        {
            this.ActiveCode = activateCode;
            this.Email = email;
        }
    }
}
