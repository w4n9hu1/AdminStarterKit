using AdminStarterKit.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStarterKit.Domain
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);

        string GenerateRefreshToken(User user);
    }
}
