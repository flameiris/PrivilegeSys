using AutoMapper;
using FlameIris.Application.ModuleApp.Dtos;
using FlameIris.Domain.Enities;
using FlameIris.Domain.IRepositories;
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
            return _moduleRepository.Insert(module);
        }
        public List<ModuleDto> GetList()
        {
            return _moduleRepository.GetAllList().Select(x => Mapper.Map<ModuleDto>(x)).ToList();
        }
        public ModuleDto GetModel(long id)
        {
            return Mapper.Map<ModuleDto>(_moduleRepository.FirstOrDefault(x => x.Id == id));
        }
        public Module Update(ModuleDto dto)
        {
            return _moduleRepository.Update(Mapper.Map<Module>(dto));
        }
        public void Delete(long[] ids)
        {
            _moduleRepository.Delete(x => ids.Contains(x.Id));
        }
    }
}
