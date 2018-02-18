using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace YourNamespace.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("")]
        public string Index() // IActionResult is the Interface that supports the various ActionResult return types from our controller methods (i.e. ViewResult)
        {
            //String describing the API functionality
            string instructions = "Instructions~~\n========================\n";
            instructions += "    Format URL as http://localhost:5000/{firstName}/{lastName}/{age}/{favColor}\n";
            return instructions;
        }
        //     return View("Index");
        // }

        [HttpGet("{FirstName}/{LastName}/{Age}/{FavColor}")]
        public JsonResult CallingCard(string firstName, string lastName, string age, string favColor)
        {
            // return $"Hello {firstName}, {lastName}, {age}, {favColor}";
            return Json(new {
                firstName = firstName, 
                lastName = lastName, 
                age = age, 
                favoriteColor = favColor
                });
        }
    }
}
