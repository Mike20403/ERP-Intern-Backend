using DotNetStarter.Common;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotNetStarter.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public (string, AuthToken?) CreateToken(User user, string tokenType = TokenTypeNames.Access)
        {

            var now = DateTime.Now;
            var tokenId = Guid.NewGuid();

            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
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
                Expires = now.AddMinutes(int.Parse(_configuration["Jwt:TokenLifetimeDuration"]!)),
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
                    ExpiredDate = now.AddMinutes(int.Parse(_configuration["Jwt:RefreshTokenLifetimeDuration"]!)),
                    Secret = Guid.NewGuid() + "-" + Guid.NewGuid(),
                }
                : null;

            return (tokenHandler.WriteToken(token), authToken);
        }
    }
}
