using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace Dojo_Survey.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index() // IActionResult is the Interface that supports the various ActionResult return types from our controller methods (i.e. ViewResult)
        {
            return View("Index"); // "Index" is not required. ASP.NET Core MVC will look for a view with the same name as the method serving it
        }
        
        [HttpPost("result")]
        public IActionResult Process(string name, string dojo_location, string favorite_language, string comment)
        {
            ViewBag.name = name;
            ViewBag.dojo_location = dojo_location;
            ViewBag.favorite_language = favorite_language;
            ViewBag.comment = comment;
            return View("Result");
        }
    }
}
