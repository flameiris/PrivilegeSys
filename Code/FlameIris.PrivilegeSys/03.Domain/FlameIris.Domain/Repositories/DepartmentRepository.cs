using FlameIris.Domain.IRepositories;
using FlameIris.Domain.Repositories;
using FlameIris.EntityFrameworkCore.Enities;
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
