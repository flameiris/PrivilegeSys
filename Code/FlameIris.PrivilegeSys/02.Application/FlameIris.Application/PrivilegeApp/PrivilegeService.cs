using AutoMapper;
using FlameIris.Application.PrivilegeApp.Dtos;
using FlameIris.Domain.Enities;
using FlameIris.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlameIris.Application.PrivilegeApp
{
    public class PrivilegeService : IPrivilegeService
    {
        private readonly IPrivilegeRepository _privilegeRepository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="userRepository">仓储对象</param>
        public PrivilegeService(IPrivilegeRepository privilegeRepository)
        {
            _privilegeRepository = privilegeRepository;
        }

        public Privilege Create(PrivilegeDto dto)
        {
            Privilege privilege = new Privilege
            {
            };
            return _privilegeRepository.Insert(privilege);
        }
        public List<PrivilegeDto> GetList()
        {
            return _privilegeRepository.GetAllList().Select(x => Mapper.Map<PrivilegeDto>(x)).ToList();
        }
        public PrivilegeDto GetModel(long id)
        {
            return Mapper.Map<PrivilegeDto>(_privilegeRepository.FirstOrDefault(x => x.Id == id));
        }
        public Privilege Update(PrivilegeDto dto)
        {
            return _privilegeRepository.Update(Mapper.Map<Privilege>(dto));
        }
        public void Delete(long[] ids)
        {
            _privilegeRepository.Delete(x => ids.Contains(x.Id));
        }
    }
}
