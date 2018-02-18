using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Form_Submission.Models;

namespace Form_Submission.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {

            // User newUser = new User
            // {
            //     first_name = first_name,
            //     last_name = last_name,
            //     age = age,
            //     email = email,
            //     password = password,
            // };
            if(ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View("Index");
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}
