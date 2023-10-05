using MediatR;

namespace DotNetStarter.Commands.Auth.ActivateAccount
{
    public sealed class ActivateAccount : IRequest
    {
        public string Email { get; }
        public string ActiveCode { get; }

        public ActivateAccount(string email, string activateCode)
        {
            ActiveCode = activateCode;
            Email = email;
        }
    }
}
