using FlameIris.EntityFrameworkCore.Enities;
using FlameIris.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using FlameIris.EntityFrameworkCore;

namespace FlameIris.Domain.Repositories
{
    public class ManagerRepository : FlameIrisRepositoryBase<Manager, Int64>, IManagerRepository
    {
        public ManagerRepository(FlameIrisDBContext dbcontext) : base(dbcontext)
        {

        }


    }
}
