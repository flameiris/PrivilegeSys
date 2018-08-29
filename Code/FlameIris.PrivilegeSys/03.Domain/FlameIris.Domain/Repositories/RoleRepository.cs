using FlameIris.Domain.IRepositories;
using FlameIris.Domain.Repositories;
using FlameIris.EntityFrameworkCore.Enities;
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

