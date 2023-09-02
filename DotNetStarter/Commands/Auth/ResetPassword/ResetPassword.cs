using MediatR;

namespace DotNetStarter.Commands.Auth.ResetPassword
{
    public sealed class ResetPassword : IRequest
    {
        public string Username { get; }

        public string Password { get; }

        public string Code { get; }

        public ResetPassword(string username, string password, string code)
        {
            Username = username;
            Password = password;
            Code = code;
        }
    }
}
