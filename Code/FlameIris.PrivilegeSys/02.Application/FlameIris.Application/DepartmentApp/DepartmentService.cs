using AutoMapper;
using FlameIris.Application.DepartmentApp.Dtos;
using FlameIris.Domain.IRepositories;
using FlameIris.EntityFrameworkCore.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlameIris.Application.DepartmentApp
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="userRepository">仓储对象</param>
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Department Create(DepartmentDto dto)
        {
            Department department = new Department
            { };
            _departmentRepository.Insert(department);
            if (_departmentRepository.SaveChanges() > 0)
                return department;
            return null;
        }
        public List<DepartmentDto> GetList()
        {
            return _departmentRepository.GetAllList().Select(x => Mapper.Map<DepartmentDto>(x)).ToList();
        }
        public DepartmentDto GetModel(long id)
        {
            return Mapper.Map<DepartmentDto>(_departmentRepository.FirstOrDefault(x => x.Id == id));
        }
        public bool Update(DepartmentDto dto)
        {
            var department = Mapper.Map<Department>(dto);
            _departmentRepository.Update(department);
            return _departmentRepository.SaveChanges() > 0;
        }
        public void Delete(long[] ids)
        {
            var deptList = _departmentRepository.GetList(x => ids.Contains(x.Id));
            foreach (var item in deptList)
            {
                _departmentRepository.Delete(item);
            }
            _departmentRepository.SaveChanges();
        }
    }
}
