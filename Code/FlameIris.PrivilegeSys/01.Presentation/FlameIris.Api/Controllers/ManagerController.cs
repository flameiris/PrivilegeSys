using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlameIris.Api.Models.Filters;
using FlameIris.Api.Models.Inputs;
using FlameIris.Application.ManagerApp;
using FlameIris.Application.ManagerApp.Dtos;
using FlameIris.Utility.Json;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace FlameIris.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Manager/[action]")]
    public class ManagerController : Controller
    {
        static Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IManagerService _managerService;
        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AjaxResult Create(ManagerDto dto)
        {
            var manager = _managerService.Create(dto);
            if (manager == null)
                return AjaxResult.Error("添加用户失败");
            return AjaxResult.Success(manager.Id);
        }
        /// <summary>
        /// 查询列表&分页
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public AjaxResult GetList(ManagerFilter filter)
        {
            var list = _managerService.GetList();
            return AjaxResult.Success(list);
        }
        /// <summary>
        /// 查询详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AjaxResult GetModel(long id)
        {
            var model = _managerService.GetModel(id);
            if (model == null)
                return AjaxResult.Error("没有找到此记录");
            return AjaxResult.Success(_managerService.GetModel(id));
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AjaxResult Update(ManagerDto dto)
        {
            var model = _managerService.Update(dto);
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
                _managerService.Delete(ids);
            }
            catch (Exception ex)
            {
                return AjaxResult.Error("参数错误");
            }
            return AjaxResult.Success();
        }

    }
}
