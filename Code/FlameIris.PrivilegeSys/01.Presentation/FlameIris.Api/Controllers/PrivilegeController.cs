using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlameIris.Api.Models.Filters;
using FlameIris.Application.PrivilegeApp;
using FlameIris.Application.PrivilegeApp.Dtos;
using FlameIris.Utility.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlameIris.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/privilege/[action]")]
    public class PrivilegeController : Controller
    {
        static Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IPrivilegeService _privilegeService;
        public PrivilegeController(IPrivilegeService privilegeService)
        {
            _privilegeService = privilegeService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AjaxResult Create(PrivilegeDto dto)
        {
            var privilege = _privilegeService.Create(dto);
            if (privilege == null)
                return AjaxResult.Error("添加用户失败");
            return AjaxResult.Success(privilege.Id);
        }
        /// <summary>
        /// 查询列表&分页
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public AjaxResult GetList(PrivilegeFilter filter)
        {
            var list = _privilegeService.GetList();
            return AjaxResult.Success(list);
        }
        /// <summary>
        /// 查询详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AjaxResult GetModel(long id)
        {
            var model = _privilegeService.GetModel(id);
            if (model == null)
                return AjaxResult.Error("没有找到此记录");
            return AjaxResult.Success(_privilegeService.GetModel(id));
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AjaxResult Update(PrivilegeDto dto)
        {
            var model = _privilegeService.Update(dto);
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
                _privilegeService.Delete(ids);
            }
            catch (Exception ex)
            {
                return AjaxResult.Error($"参数错误,StackTrace={{{ex.StackTrace}}}");
            }
            return AjaxResult.Success();
        }
    }
}
