using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlameIris.Api.Models.Filters;
using FlameIris.Application.ManagerApp;
using FlameIris.Utility.Json;
using Microsoft.AspNetCore.Mvc;
using NLog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        public AjaxResult GetList(ManagerFilter filter)
        {
            var list = _managerService.GetList();
            Logger.Info($"获取到数据啦啦啦啦  {string.Join(",", list.Select(x => x.NickName).ToArray())}");
            return AjaxResult.Success(list);
        }
        public AjaxResult GetModel(long id)
        {
            var model = _managerService.GetModel(id);
            if (model == null)
                return AjaxResult.Error("没有找到此记录");
            return AjaxResult.Success(_managerService.GetModel(id));
        }
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
