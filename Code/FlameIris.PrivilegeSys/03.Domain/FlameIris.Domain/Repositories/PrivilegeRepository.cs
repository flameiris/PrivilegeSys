using FlameIris.Domain.IRepositories;
using FlameIris.Domain.Repositories;
using FlameIris.EntityFrameworkCore.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.EntityFrameworkCore.Repositories
{
    public class PrivilegeRepository : FlameIrisRepositoryBase<Privilege, Int64>, IPrivilegeRepository
    {
        public PrivilegeRepository(FlameIrisDBContext dbcontext) : base(dbcontext)
        {

        }
    }
}
