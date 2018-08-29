using FlameIris.EntityFrameworkCore.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.Domain.IRepositories
{
    /// <summary>
    /// 管理员管理仓储接口
    /// </summary>
    public interface IManagerRepository : IRepository<Manager, Int64>
    {

    }
}
