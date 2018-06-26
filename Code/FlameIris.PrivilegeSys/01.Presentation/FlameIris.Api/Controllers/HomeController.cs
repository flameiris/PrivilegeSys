using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlameIris.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Home/[action]")]
    public class HomeController : Controller
    {
        public async Task<string> Index()
        {

            return await Task.Run(() =>
            {
                var ip2 = HttpContext.Connection.RemoteIpAddress.ToString();
                
                Thread.Sleep(1500);
                return $"IP:{ip2}";
            });
        }
    }
}