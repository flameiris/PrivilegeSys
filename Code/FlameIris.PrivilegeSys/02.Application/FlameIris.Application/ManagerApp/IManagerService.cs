using FlameIris.Application.ManagerApp.Dtos;
using FlameIris.EntityFrameworkCore.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.Application.ManagerApp
{
    public interface IManagerService
    {
        Manager Create(ManagerDto dto);
        List<ManagerDto> GetList();
        ManagerDto GetModel(long id);
        bool Update(ManagerDto dto);
        void Delete(long[] ids);
    }
}
