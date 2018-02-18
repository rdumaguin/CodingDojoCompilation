using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Home() // IActionResult is the Interface that supports the various ActionResult return types from our controller methods (i.e. ViewResult)
        {
            return View("Index"); // "Index" is not required. ASP.NET Core MVC will look for a view with the same name as the method serving it
        }
        
        [HttpGet("Projects")]
        public IActionResult Projects()
        {
            return View("Projects");
        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            return View("Contact");
        }
    }
}
