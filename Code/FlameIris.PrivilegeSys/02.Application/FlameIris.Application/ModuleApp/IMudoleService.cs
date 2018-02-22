using FlameIris.Application.ModuleApp.Dtos;
using FlameIris.Domain.Enities;
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
        Module Update(ModuleDto module);
        void Delete(long[] ids);
    }
}
