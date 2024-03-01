using AdminStarterKit.Domain.Enums;

namespace AdminStarterKit.Application
{
    public interface ITokenService
    {
        string GenerateToken(string username, Role role);
    }
}
