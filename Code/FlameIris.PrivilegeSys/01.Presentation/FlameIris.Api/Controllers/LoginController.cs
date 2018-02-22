using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlameIris.Api.Models.Inputs;
using FlameIris.Utility.Json;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlameIris.Api.Controllers
{
    [Route("api/login/[action]")]
    public class LoginController : Controller
    {
        public AjaxResult Login(LoginInput input)
        {
            input = new LoginInput()
            {
                username = "yq1",
                password = "123456"
            };
            return AjaxResult.Success();
        }

        public AjaxResult LogOut()
        {
            return AjaxResult.Success();
        }
    }
}
