using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlameIris.Api.Models.Filters;
using FlameIris.Application.RoleApp;
using FlameIris.Application.RoleApp.Dtos;
using FlameIris.Utility.Json;
using Microsoft.AspNetCore.Mvc;
using NLog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlameIris.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Role/[action]")]
    public class RoleController : Controller
    {
        static Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AjaxResult Create(RoleDto dto)
        {
            var role = _roleService.Create(dto);
            if (role == null)
                return AjaxResult.Error("添加角色失败");
            return AjaxResult.Success(role.Id);
        }
        /// <summary>
        /// 查询列表&分页
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public AjaxResult GetList(RoleFilter filter)
        {
            var list = _roleService.GetList();
            return AjaxResult.Success(list);
        }
        /// <summary>
        /// 查询详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AjaxResult GetModel(long id)
        {
            var model = _roleService.GetModel(id);
            if (model == null)
                return AjaxResult.Error("没有找到此记录");
            return AjaxResult.Success(_roleService.GetModel(id));
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AjaxResult Update(RoleDto dto)
        {
            var model = _roleService.Update(dto);
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
                _roleService.Delete(ids);
            }
            catch (Exception ex)
            {
                return AjaxResult.Error($"参数错误,StackTrace={{{ex.StackTrace}}}");
            }
            return AjaxResult.Success();
        }
    }
}
