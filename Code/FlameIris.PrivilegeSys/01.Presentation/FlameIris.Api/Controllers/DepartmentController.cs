using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlameIris.Api.Models.Filters;
using FlameIris.Application.DepartmentApp;
using FlameIris.Application.DepartmentApp.Dtos;
using FlameIris.Utility.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlameIris.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/department/[action]")]
    public class DepartmentController : Controller
    {
        static Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AjaxResult Create(DepartmentDto dto)
        {
            var department = _departmentService.Create(dto);
            if (department == null)
                return AjaxResult.Error("添加用户失败");
            return AjaxResult.Success(department.Id);
        }
        /// <summary>
        /// 查询列表&分页
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public AjaxResult GetList(DepartmentFilter filter)
        {
            var list = _departmentService.GetList();
            return AjaxResult.Success(list);
        }
        /// <summary>
        /// 查询详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AjaxResult GetModel(long id)
        {
            var model = _departmentService.GetModel(id);
            if (model == null)
                return AjaxResult.Error("没有找到此记录");
            return AjaxResult.Success(_departmentService.GetModel(id));
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AjaxResult Update(DepartmentDto dto)
        {
            var flag = _departmentService.Update(dto);
            if (!flag)
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
                _departmentService.Delete(ids);
            }
            catch (Exception ex)
            {
                return AjaxResult.Error($"参数错误,StackTrace={{{ex.StackTrace}}}");
            }
            return AjaxResult.Success();
        }
    }
}
