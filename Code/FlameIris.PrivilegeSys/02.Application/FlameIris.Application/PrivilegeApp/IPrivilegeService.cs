using FlameIris.Application.PrivilegeApp.Dtos;
using FlameIris.Domain.Enities;
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
        Privilege Update(PrivilegeDto dto);
        void Delete(long[] ids);
    }
}
