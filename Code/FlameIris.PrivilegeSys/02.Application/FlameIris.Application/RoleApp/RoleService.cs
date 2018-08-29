using AutoMapper;
using FlameIris.Application.RoleApp.Dtos;
using FlameIris.EntityFrameworkCore.Enities;
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
            _roleRepository.Insert(role);
            if (_roleRepository.SaveChanges() > 0)
                return role;
            return null;
        }
        public List<RoleDto> GetList()
        {
            return _roleRepository.GetAllList().Select(x => Mapper.Map<RoleDto>(x)).ToList();
        }
        public RoleDto GetModel(long id)
        {
            return Mapper.Map<RoleDto>(_roleRepository.FirstOrDefault(x => x.Id == id));
        }
        public bool Update(RoleDto dto)
        {
            var role = Mapper.Map<Role>(dto);
            _roleRepository.Update(role);
            return _roleRepository.SaveChanges() > 0;
        }
        public void Delete(long[] ids)
        {
            var roleList = _roleRepository.GetList(x => ids.Contains(x.Id));
            foreach (var item in roleList)
            {
                _roleRepository.Delete(item);
            }
            _roleRepository.SaveChanges();
        }
    }
}