using FlameIris.Domain.Enities;
using FlameIris.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.EntityFrameworkCore.Repositories
{
    public class ManagerRepository : FlameIrisRepositoryBase<Manager, Int64>, IManagerRepository
    {
        public ManagerRepository(FlameIrisDBContext dbcontext) : base(dbcontext)
        {

        }

        
    }
}
