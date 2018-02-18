using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet("")]
        public IActionResult Index()
        {
            // ViewBag.AllUsers = _context.Users.ToList(); // Temporary container to foreach through
            // List<User> AllUsers = _context.Users.ToList(); 
            var UserIndex = new UserIndex()
            {
                Users = _context.Users.ToList(), // List<User>
                // LoginUser = new LoginUser(),
                // RegisterUser = new RegisterUser()
            };
            // return View(AllUsers); // Passing List<User> object as our Model to foreach through
            return View(UserIndex); // Passing ViewModel instead
        }

    // LOGIN AND REGISTRATION
        [HttpPost("login")]
        public IActionResult Login(string login_email, string login_password)
        {
            User user = _context.Users.Where(u => u.Email == login_email).SingleOrDefault();
            if(user != null && login_password != null) // Valid email was found, and a valid/invalid password was entered
            {
                var hasher = new PasswordHasher<User>();
                if(hasher.VerifyHashedPassword(user, user.Password, login_password) > 0)
                {
                    HttpContext.Session.SetInt32("UserId", user.UserId); // Saving "Id" to session for View access later!
                    // return Json(user.UserId);
                    return RedirectToAction("Index", "WeddingPlanner");
                }
            }

            ViewBag.Email = login_email; // Pass email back to the form
            TempData["Error"] = "Invalid Email/Password"; // Using TempData since we just need one error flashed to the View!
            
            var UserIndex = new UserIndex()
            {
                Users = _context.Users.ToList(), // List<User>
                // LoginUser = new LoginUser(),
                // RegisterUser = new RegisterUser()
            };
            return View("Index", UserIndex);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUser user)
        {
            // Verify that email hasn't been registered before
            // if(_context.Users.Where(u => u.Email == user.Email).ToList().Count > 0)
            if(_context.Users.Where(u => u.Email == user.Email).SingleOrDefault() != null)
                ModelState.AddModelError("Email", "This Email is already registered!");
            if(ModelState.IsValid)
            {
                PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
                string hashed = hasher.HashPassword(user, user.Password);

                User NewUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = hashed
                };

                User theUser = _context.Add(NewUser).Entity; // Gets the Entity being tracked by this entry
                // OR _context.Users.Add(NewUser);
                _context.SaveChanges();
                int NewUserId = _context.Users.Last().UserId; // Or simply pass in theUser.UserId to session
                HttpContext.Session.SetInt32("UserId", NewUserId); // (int) InvalidCastException: Unable to cast object of type 'System.UInt64' to type 'System.Int32'.
                // return Json(NewUser.UserId);
                return RedirectToAction("Index", "WeddingPlanner");
            }
            
            var UserIndex = new UserIndex()
            {
                Users = _context.Users.ToList(), // List<User>
                // LoginUser = new LoginUser(),
                // RegisterUser = user
            };
            return View("Index", UserIndex);
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            return View();
        }

        [HttpGet("user/{id}")]
        public IActionResult Show(int id)
        {
            User theUser = _context.Users.SingleOrDefault(user => user.UserId == id);
            return View(theUser);
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
