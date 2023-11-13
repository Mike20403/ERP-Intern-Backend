using DotNetStarter.Common;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Services.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotNetStarter.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly AppSettings _appSettings;
        public TokenService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public (string, AuthToken?) CreateToken(User user, string tokenType = TokenTypeNames.Access)
        {

            var now = DateTime.Now;
            var tokenId = Guid.NewGuid();

            var issuer = _appSettings.Jwt.Issuer;
            var audience = _appSettings.Jwt.Audience;
            var key = Encoding.ASCII.GetBytes(_appSettings.Jwt.Key!);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, tokenId.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToString(CultureInfo.InvariantCulture)),
                new Claim(ClaimTypes.Role, user.Role!.Name),
            };
            claims.AddRange(user.Privileges.Select(privilege => new Claim(HttpContextExtensions.PrivilegesClaimName, privilege.Name)));

            claims.Add(new Claim(DomainConstraints.TokenType, tokenType));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = now.AddMinutes(_appSettings.Jwt.TokenLifetimeDuration!),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature),
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var authToken = tokenType == TokenTypeNames.Access
                ? new AuthToken
                {
                    IsUsed = false,
                    UserId = user!.Id,
                    TokenId = tokenId,
                    ExpiredDate = now.AddMinutes(_appSettings.Jwt.RefreshTokenLifetimeDuration),
                    Secret = Guid.NewGuid() + "-" + Guid.NewGuid(),
                }
                : null;

            return (tokenHandler.WriteToken(token), authToken);
        }
    }
}
