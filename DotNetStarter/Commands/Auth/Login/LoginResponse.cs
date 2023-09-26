namespace DotNetStarter.Commands.Auth.Login
{
    public sealed class LoginResponse
    {
        public string Token { get; }

        public string Secret { get; }

        public LoginResponse(string token, string secret)
        {
            Token = token;
            Secret = secret;
        }
    }
}
