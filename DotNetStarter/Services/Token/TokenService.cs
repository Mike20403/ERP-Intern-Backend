using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using DotNetStarter.Entities;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotNetStarter.Extensions;

namespace DotNetStarter.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(User user)
        {
            var now = DateTime.Now;
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToString(CultureInfo.InvariantCulture)),
                new Claim(ClaimTypes.Role, user.Role!.Name),
            };
            claims.AddRange(user.Privileges.Select(privilege => new Claim(HttpContextExtensions.PrivilegesClaimName, privilege.Name)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = now.AddMinutes(30),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature),
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
