using FlameIris.Domain.Enities;
using FlameIris.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.EntityFrameworkCore.Repositories
{
    public class RoleRepository : FlameIrisRepositoryBase<Role, Int64>, IRoleRepository
    {
        public RoleRepository(FlameIrisDBContext dbcontext) : base(dbcontext)
        {

        }
    }
}

