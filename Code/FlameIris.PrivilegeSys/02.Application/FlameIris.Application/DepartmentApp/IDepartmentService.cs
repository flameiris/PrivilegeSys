using FlameIris.Application.DepartmentApp.Dtos;
using FlameIris.EntityFrameworkCore.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.Application.DepartmentApp
{
    public interface IDepartmentService
    {
        Department Create(DepartmentDto dto);
        List<DepartmentDto> GetList();
        DepartmentDto GetModel(long id);
        bool Update(DepartmentDto dto);
        void Delete(long[] ids);

    }
}
