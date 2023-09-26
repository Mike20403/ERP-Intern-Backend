using DotNetStarter.Entities;

namespace DotNetStarter.Services.Token
{
    public interface ITokenService
    {
        (string, AuthToken) CreateToken(User user);
    }
}
