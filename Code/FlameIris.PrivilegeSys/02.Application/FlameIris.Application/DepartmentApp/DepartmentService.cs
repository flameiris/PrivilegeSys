using AutoMapper;
using FlameIris.Application.DepartmentApp.Dtos;
using FlameIris.Domain.Enities;
using FlameIris.Domain.IRepositories;
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
            return _departmentRepository.Insert(department);
        }
        public List<DepartmentDto> GetList()
        {
            return _departmentRepository.GetAllList().Select(x => Mapper.Map<DepartmentDto>(x)).ToList();
        }
        public DepartmentDto GetModel(long id)
        {
            return Mapper.Map<DepartmentDto>(_departmentRepository.FirstOrDefault(x => x.Id == id));
        }
        public Department Update(DepartmentDto dto)
        {
            return _departmentRepository.Update(Mapper.Map<Department>(dto));
        }
        public void Delete(long[] ids)
        {
            _departmentRepository.Delete(x => ids.Contains(x.Id));
        }
    }
}
