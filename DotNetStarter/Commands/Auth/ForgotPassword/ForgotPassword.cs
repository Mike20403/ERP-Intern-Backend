using MediatR;

namespace DotNetStarter.Commands.Auth.ForgotPassword
{
    public sealed class ForgotPassword : IRequest
    {
        public string Username { get; }

        public ForgotPassword(string username)
        {
            Username = username;
        }
    }
}
