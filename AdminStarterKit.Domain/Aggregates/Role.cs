using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStarterKit.Domain.Aggregates
{
    public class Role : Entity, IAggregateRoot
    {
        public string RoleName { get; set; }

        public DateTimeOffset CreatedDateTime { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
