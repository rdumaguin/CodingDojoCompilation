using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginRegistration.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser user) // LogRegBundle model
        {
            // LoginUser user = model.Login;
            // Validate Email
            string checkEmail = $"SELECT Id, Password FROM users WHERE Email = '{user.LoginEmail}'";
            var emailMatch = DbConnector.Query(checkEmail);
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            if(user.LoginPassword != null) // (providedPassword) ArgumentNullException: Value cannot be null.
            {
                if(emailMatch.Count == 0 || hasher.VerifyHashedPassword(user, (string)emailMatch[0]["Password"], user.LoginPassword) == 0) 
                {
                        ModelState.AddModelError("LoginEmail", "Invalid Email/Password!");
                }
            }
            if(ModelState.IsValid)
            {
                HttpContext.Session.SetInt32("Id", (int)emailMatch[0]["Id"]); // Saving "Id" to session for View access later!
                return RedirectToAction("Success");
            }
            // LogRegBundle ViewBundle = new LogRegBundle{ Login = user };
            return View("Index");
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUser user) // LogRegBundle model
        {
            // RegisterUser user = model.Register;
            // Verify that email hasn't been registered before
            string checkEmail = $"SELECT Email FROM users WHERE Email = '{user.Email}'";
            if(DbConnector.Query(checkEmail).Count > 0)
                ModelState.AddModelError("Email", "This Email is already registered!");

            if(ModelState.IsValid)
            {
                PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
                string hashed = hasher.HashPassword(user, user.Password);

                string query = $"INSERT INTO users (FirstName, LastName, Email, Password, CreatedAt, UpdatedAt) VALUES ('{user.FirstName}','{user.LastName}','{user.Email}','{hashed}',NOW(),NOW()); SELECT LAST_INSERT_ID() as Id"; // Query instead of Execute in order to grab the Id!
                var thisUser = DbConnector.Query(query);
                HttpContext.Session.SetInt32("Id", Convert.ToInt32(thisUser[0]["Id"])); // (int) InvalidCastException: Unable to cast object of type 'System.UInt64' to type 'System.Int32'.
                return Json(thisUser); // "Id": ?
                // return RedirectToAction("Success");
            }
            // LogRegBundle ViewBundle = new LogRegBundle{ Register = user };
            return View("Index");
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            return View();
        }

    }
}
