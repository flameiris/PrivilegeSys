using FlameIris.Application.ModuleApp.Dtos;
using FlameIris.EntityFrameworkCore.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.Application.ModuleApp
{
    public interface IModuleService
    {
        Module Create(ModuleDto dto);
        List<ModuleDto> GetList();
        ModuleDto GetModel(long id);
        bool Update(ModuleDto module);
        void Delete(long[] ids);
    }
}
