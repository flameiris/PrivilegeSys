using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlameIris.Api.Models.Filters;
using FlameIris.Application.ModuleApp;
using FlameIris.Application.ModuleApp.Dtos;
using FlameIris.Utility.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlameIris.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Module/[action]")]
    public class ModuleController : Controller
    {
        static Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IModuleService _moduleService;
        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AjaxResult Create(ModuleDto dto)
        {
            var module = _moduleService.Create(dto);
            if (module == null)
                return AjaxResult.Error("添加用户失败");
            return AjaxResult.Success(module.Id);
        }
        /// <summary>
        /// 查询列表&分页
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public AjaxResult GetList(ModuleFilter filter)
        {
            var list = _moduleService.GetList();
            return AjaxResult.Success(list);
        }
        /// <summary>
        /// 查询详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AjaxResult GetModel(long id)
        {
            var model = _moduleService.GetModel(id);
            if (model == null)
                return AjaxResult.Error("没有找到此记录");
            return AjaxResult.Success(_moduleService.GetModel(id));
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AjaxResult Update(ModuleDto dto)
        {
            var model = _moduleService.Update(dto);
            if (model == null)
                return AjaxResult.Error("修改用户失败");
            return AjaxResult.Success();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idStr"></param>
        /// <returns></returns>
        public AjaxResult Delete(string idStr)
        {
            try
            {
                var idsStr = idStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var ids = Array.ConvertAll(idsStr, x => Convert.ToInt64(x));
                _moduleService.Delete(ids);
            }
            catch (Exception ex)
            {
                return AjaxResult.Error($"参数错误,StackTrace={{{ex.StackTrace}}}");
            }
            return AjaxResult.Success();
        }
    }
}
