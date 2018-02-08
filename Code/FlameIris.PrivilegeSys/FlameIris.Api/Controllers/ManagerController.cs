using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        //public JsonResult GetList()
        //{

        //}
    }
}
