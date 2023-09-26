using MediatR;

namespace DotNetStarter.Commands.Account.ConfirmChangeEmail
{
    public sealed class ConfirmChangeEmail : IRequest
    {
        public string CurrentEmail { get; }

        public string NewEmail { get; }

        public string ActiveCode { get; }

        public ConfirmChangeEmail(string currentEmail, string newEmail, string activeCode)
        {
            this.CurrentEmail = currentEmail;
            this.NewEmail = newEmail;
            this.ActiveCode = activeCode;
        }
    }
}