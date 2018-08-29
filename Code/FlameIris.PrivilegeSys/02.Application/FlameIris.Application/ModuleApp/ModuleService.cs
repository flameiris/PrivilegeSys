using AutoMapper;
using FlameIris.Application.ModuleApp.Dtos;
using FlameIris.Domain.IRepositories;
using FlameIris.EntityFrameworkCore.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlameIris.Application.ModuleApp
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="userRepository">仓储对象</param>
        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public Module Create(ModuleDto dto)
        {
            Module module = new Module
            {

            };
            _moduleRepository.Insert(module);
            if (_moduleRepository.SaveChanges() > 0)
                return module;
            return null;
        }
        public List<ModuleDto> GetList()
        {
            return _moduleRepository.GetAllList().Select(x => Mapper.Map<ModuleDto>(x)).ToList();
        }
        public ModuleDto GetModel(long id)
        {
            return Mapper.Map<ModuleDto>(_moduleRepository.FirstOrDefault(x => x.Id == id));
        }
        public bool Update(ModuleDto dto)
        {
            var module = Mapper.Map<Module>(dto);
            _moduleRepository.Update(module);
            return _moduleRepository.SaveChanges() > 0;
        }
        public void Delete(long[] ids)
        {
            var moduleList = _moduleRepository.GetList(x => ids.Contains(x.Id));
            foreach (var item in moduleList)
            {
                _moduleRepository.Delete(item);
            }
            _moduleRepository.SaveChanges();
        }
    }
}
