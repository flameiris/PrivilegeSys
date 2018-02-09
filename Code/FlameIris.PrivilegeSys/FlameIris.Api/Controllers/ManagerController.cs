using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlameIris.Api.Models.Filters;
using FlameIris.Application.ManagerApp;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlameIris.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Manager/[action]")]
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;
        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public JsonResult GetList(ManagerFilter filter)
        {
            return new JsonResult(_managerService.GetList());
        }
        public JsonResult GetModel(long id)
        {
            return new JsonResult(_managerService.GetModel(id));
        }
        public JsonResult Delete(string idStr)
        {
            try
            {
                var idsStr = idStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var ids = Array.ConvertAll(idsStr, x => Convert.ToInt64(x));
                _managerService.Delete(ids);
            }
            catch (Exception ex)
            {
                return new JsonResult("参数错误");
            }
            return new JsonResult("OK");
        }
    }
}
