﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace problem.Controllers
{
    [ApiController]
    //[Route("api/Home")]
    [Route("Name")]
    public class HomeController : Controller
    {
        // GET: /<controller>/
    /*    public IActionResult Index()
        {
            return View();
        }*/

        [HttpGet(Name = "GetHome")]
        public string GetName()
        {
            string name = "Berker";
            return name;
           
        }
    }
}

