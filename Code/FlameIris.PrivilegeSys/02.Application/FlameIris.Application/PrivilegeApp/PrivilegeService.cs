using AutoMapper;
using FlameIris.Application.PrivilegeApp.Dtos;
using FlameIris.Domain.IRepositories;
using FlameIris.EntityFrameworkCore.Enities;
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
            _privilegeRepository.Insert(privilege);
            if (_privilegeRepository.SaveChanges() > 0)
                return privilege;
            return null;
        }
        public List<PrivilegeDto> GetList()
        {
            return _privilegeRepository.GetAllList().Select(x => Mapper.Map<PrivilegeDto>(x)).ToList();
        }
        public PrivilegeDto GetModel(long id)
        {
            return Mapper.Map<PrivilegeDto>(_privilegeRepository.FirstOrDefault(x => x.Id == id));
        }
        public bool Update(PrivilegeDto dto)
        {
            var privilege = Mapper.Map<Privilege>(dto);
            _privilegeRepository.Update(privilege);
            return _privilegeRepository.SaveChanges() > 0;
        }
        public void Delete(long[] ids)
        {
            var privilegeList = _privilegeRepository.GetList(x => ids.Contains(x.Id));
            foreach (var item in privilegeList)
            {
                _privilegeRepository.Delete(item);
            }
            _privilegeRepository.SaveChanges();
        }
    }
}
