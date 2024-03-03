using AdminStarterKit.Domain.Enums;
using AdminStarterKit.Domain.Identity;

namespace AdminStarterKit.Application
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);

        string GenerateRefreshToken(User user);
    }
}
