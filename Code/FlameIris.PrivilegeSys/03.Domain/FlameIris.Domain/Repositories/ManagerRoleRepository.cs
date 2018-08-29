using FlameIris.Domain.IRepositories;
using FlameIris.Domain.Repositories;
using FlameIris.EntityFrameworkCore.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.EntityFrameworkCore.Repositories
{
    public class ManagerRoleRepository : FlameIrisRepositoryBase<ManagerRole, Int64>, IManagerRoleRepository
    {
        public ManagerRoleRepository(FlameIrisDBContext dbcontext) : base(dbcontext)
        {

        }
    }
}
