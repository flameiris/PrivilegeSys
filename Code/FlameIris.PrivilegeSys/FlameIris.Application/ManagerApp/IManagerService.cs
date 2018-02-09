using FlameIris.Application.ManagerApp.Dtos;
using FlameIris.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.Application.ManagerApp
{
    public interface IManagerService
    {
        Manager Create(ManagerDto dto);
        List<ManagerDto> GetList();
        Manager GetModel(long id);
        Manager Update(Manager manager);
        bool Delete(long[] ids);



    }
}
