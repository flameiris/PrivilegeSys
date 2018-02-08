using System;
using System.Collections.Generic;
using System.Text;
using FlameIris.Application.ManagerApp.Dtos;
using FlameIris.Domain.Enities;
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
            return _managerRepository.Insert(manager);
        }
    }
}
