﻿using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStarterKit.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();
    }
}
