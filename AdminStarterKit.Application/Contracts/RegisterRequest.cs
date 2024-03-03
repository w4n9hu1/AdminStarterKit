using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStarterKit.Application.Contracts
{
    public class RegisterRequest
    {
        public required string Email { get; init; }
        public required string Password { get; init; }
    }
}
