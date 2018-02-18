using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BankAccounts.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("")]
        public IActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<RegisterViewModel> hasher = new PasswordHasher<RegisterViewModel>();
                string hashed = hasher.HashPassword(model, model.Password);

                User NewUser = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = hashed
                };

                _context.Add(NewUser);
                // OR _context.Users.Add(NewUser);
                _context.SaveChanges();
                int NewUserId = _context.Users.Last().Id;
                HttpContext.Session.SetInt32("UserId", NewUserId); // (int) InvalidCastException: Unable to cast object of type 'System.UInt64' to type 'System.Int32'.
                // return Json(NewUser); // "id": ?
                return RedirectToAction("Account", "Account", new {id = NewUserId});
            }
            // LogRegBundle ViewBundle = new LogRegBundle{ Register = user };
            return View("Register");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser(string email, string password)
        {
            User user = _context.Users.Where(u => u.Email == email).SingleOrDefault();
            if(user != null && password != null) // Valid email was found, and a valid/invalid password was entered
            {
                var hasher = new PasswordHasher<User>();
                if(hasher.VerifyHashedPassword(user, user.Password, password) > 0)
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    return RedirectToAction("Account", "Account", new {id = user.Id});
                }
            }
            TempData["Error"] = "Invalid Email/Password"; // Using TempData since we just need one error flashed to the View!
            return View("Login");
        }
        
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}
