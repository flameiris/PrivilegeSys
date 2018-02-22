using FlameIris.Application.RoleApp.Dtos;
using FlameIris.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.Application.RoleApp
{
    public interface IRoleService
    {
        Role Create(RoleDto dto);
        List<RoleDto> GetList();
        RoleDto GetModel(long id);
        Role Update(RoleDto role);
        void Delete(long[] ids);
    }
}
