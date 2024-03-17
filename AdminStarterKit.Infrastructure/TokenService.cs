using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Aggregates;
using AdminStarterKit.Domain.Shared;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
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
                new(ClaimTypes.Name, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
            };
            if (user.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
            }
            if (user.Roles?.Count() > 0)
            {
                foreach (var role in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
                }
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