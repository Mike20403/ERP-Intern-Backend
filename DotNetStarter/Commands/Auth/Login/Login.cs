using MediatR;

namespace DotNetStarter.Commands.Auth.Login
{
    public sealed class Login : IRequest<LoginResponse>
    {
        public string Username { get; }

        public string Password { get; }

        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
