using FlameIris.Domain.Enities;
using FlameIris.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.EntityFrameworkCore.Repositories
{
    public class DepartmentRepository : FlameIrisRepositoryBase<Department, Int64>, IDepartmentRepository
    {
        public DepartmentRepository(FlameIrisDBContext dbcontext) : base(dbcontext)
        {

        }
    }
}
