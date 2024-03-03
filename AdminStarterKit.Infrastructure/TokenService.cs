using AdminStarterKit.Application;
using AdminStarterKit.Domain.Identity;
using AdminStarterKit.Domain.Shared;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AdminStarterKit.Infrastructure
{
    public class TokenService : ITokenService
    {
        private readonly JwtConfig _jwtConfig;

        public TokenService(IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        public string GenerateAccessToken(User user)
        {
            return GenerateToken(user, _jwtConfig.ExpiryInMinutes);
        }

        public string GenerateRefreshToken(User user)
        {
            return GenerateToken(user, _jwtConfig.RefreshTokenExpiryInMinutes);
        }

        private string GenerateToken(User user, int expiryInMinutes)
        {
            var key = Encoding.UTF8.GetBytes(_jwtConfig.Key);
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserId.ToString()),
            };
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name.ToString()));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience,
                Expires = DateTime.UtcNow.AddMinutes(expiryInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
