using FlameIris.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.Domain.IRepositories
{
    public interface IModuleRepository : IRepository<Module, Int64>
    {
    }
}
