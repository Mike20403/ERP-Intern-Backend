using DotNetStarter.Entities;

namespace DotNetStarter.Services.Token
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
