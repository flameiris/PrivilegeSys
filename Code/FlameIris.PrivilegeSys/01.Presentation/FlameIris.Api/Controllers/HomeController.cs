﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlameIris.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Home/[action]")]
    public class HomeController : Controller
    {
        public string Index()
        {
            return "ok";
        }
    }
}