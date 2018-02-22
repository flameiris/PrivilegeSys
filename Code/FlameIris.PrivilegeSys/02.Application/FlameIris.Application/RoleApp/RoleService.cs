using AutoMapper;
using FlameIris.Application.RoleApp.Dtos;
using FlameIris.Domain.Enities;
using FlameIris.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlameIris.Application.RoleApp
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="userRepository">仓储对象</param>
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Role Create(RoleDto dto)
        {
            Role role = new Role
            {

            };
            return _roleRepository.Insert(role);
        }
        public List<RoleDto> GetList()
        {
            return _roleRepository.GetAllList().Select(x => Mapper.Map<RoleDto>(x)).ToList();
        }
        public RoleDto GetModel(long id)
        {
            return Mapper.Map<RoleDto>(_roleRepository.FirstOrDefault(x => x.Id == id));
        }
        public Role Update(RoleDto dto)
        {
            return _roleRepository.Update(Mapper.Map<Role>(dto));
        }
        public void Delete(long[] ids)
        {
            _roleRepository.Delete(x => ids.Contains(x.Id));
        }
    }
}