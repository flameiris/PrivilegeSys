using FlameIris.Domain.Enities;
using FlameIris.Domain.IRepositories;
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
