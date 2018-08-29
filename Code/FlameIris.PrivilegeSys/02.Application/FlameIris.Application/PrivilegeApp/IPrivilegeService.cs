using FlameIris.Application.PrivilegeApp.Dtos;
using FlameIris.EntityFrameworkCore.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.Application.PrivilegeApp
{
    public interface IPrivilegeService
    {
        Privilege Create(PrivilegeDto dto);
        List<PrivilegeDto> GetList();
        PrivilegeDto GetModel(long id);
        bool Update(PrivilegeDto dto);
        void Delete(long[] ids);
    }
}
