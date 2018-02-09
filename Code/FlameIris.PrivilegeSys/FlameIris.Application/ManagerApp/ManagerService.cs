using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FlameIris.Application.ManagerApp.Dtos;
using FlameIris.Domain.Enities;
using FlameIris.Domain.IRepositories;
using AutoMapper;

namespace FlameIris.Application.ManagerApp
{
    public class ManagerService : IManagerService
    {
        //管理员管理仓储接口
        private readonly IManagerRepository _managerRepository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="userRepository">仓储对象</param>
        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public Manager Create(ManagerDto dto)
        {
            Manager manager = new Manager
            {
                NickName = dto.NickName,
                Username = dto.Username,
                Password = dto.Password,
                DeptId = dto.DeptId
            };
            return _managerRepository.Insert(manager);
        }
        public List<ManagerDto> GetList()
        {
            return _managerRepository.GetAllList().Select(x => Mapper.Map<ManagerDto>(x)).ToList();
        }
        public Manager GetModel(long id)
        {
            return _managerRepository.FirstOrDefault(x => x.Id == id);
        }
        public Manager Update(Manager manager)
        {
            return _managerRepository.Update(manager);
        }
        public bool Delete(long[] ids)
        {
            _managerRepository.Delete(x => ids.Contains(x.Id));
            return true;
        }



    }
}
