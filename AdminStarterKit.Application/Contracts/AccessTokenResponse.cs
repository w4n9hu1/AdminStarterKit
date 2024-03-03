using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStarterKit.Application.Contracts
{
    public class AccessTokenResponse
    {
        public required string AccessToken { get; init; }
        public required string RefreshToken { get; init; }
    }
}
