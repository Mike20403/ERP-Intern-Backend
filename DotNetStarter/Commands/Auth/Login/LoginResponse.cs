namespace DotNetStarter.Commands.Auth.Login
{
    public sealed class LoginResponse
    {
        public string Token { get; }

        public LoginResponse(string token)
        {
            Token = token;
        }
    }
}
