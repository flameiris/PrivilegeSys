using FlameIris.Domain.IRepositories;
using FlameIris.Domain.Repositories;
using FlameIris.EntityFrameworkCore.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.EntityFrameworkCore.Repositories
{
    public class ModuleRepository : FlameIrisRepositoryBase<Module, Int64>, IModuleRepository
    {
        public ModuleRepository(FlameIrisDBContext dbcontext) : base(dbcontext)
        {

        }
    }
}
