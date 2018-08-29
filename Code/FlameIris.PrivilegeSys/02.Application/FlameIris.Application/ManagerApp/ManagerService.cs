using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FlameIris.Application.ManagerApp.Dtos;
using AutoMapper;
using FlameIris.EntityFrameworkCore.Enities;
using FlameIris.Domain.IRepositories;

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
            _managerRepository.Insert(manager);
            if (_managerRepository.SaveChanges() > 0)
                return manager;
            return null;
        }
        public List<ManagerDto> GetList()
        {
            return _managerRepository.GetAllList().Select(x => Mapper.Map<ManagerDto>(x)).ToList();
        }
        public ManagerDto GetModel(long id)
        {
            return Mapper.Map<ManagerDto>(_managerRepository.FirstOrDefault(x => x.Id == id));
        }
        public bool Update(ManagerDto dto)
        {
            var manager = Mapper.Map<Manager>(dto);
            _managerRepository.Update(manager);
            return _managerRepository.SaveChanges() > 0;
        }
        public void Delete(long[] ids)
        {
            var managerList = _managerRepository.GetList(x => ids.Contains(x.Id));
            foreach (var item in managerList)
            {
                _managerRepository.Delete(item);
            }
            _managerRepository.SaveChanges();
        }
    }
}
