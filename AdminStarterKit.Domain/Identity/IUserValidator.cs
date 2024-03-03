using AdminStarterKit.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStarterKit.Domain.Identity
{
    public interface IUserValidator
    {
        Task<ActionResult> ValidateAsync(User user);
    }
}
