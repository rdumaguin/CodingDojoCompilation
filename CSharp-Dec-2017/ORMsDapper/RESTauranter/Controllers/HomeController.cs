using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RESTauranter.Models;
using System.Linq;

namespace RESTauranter.Controllers
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
            return View();
        }

        [HttpGet("reviews")]
        public IActionResult Reviews()
        {
            List<Review> AllReviews = _context.reviews.OrderByDescending(r => r.date_visited).ToList();
            
            return View(AllReviews);
        }

        [HttpPost("create")]
        public IActionResult Create(Review review)
        {
            if(ModelState.IsValid)
            {
                // Entity Framework is smart enough to look for a DbSet that contains the appropriate object type and save the new entry there. If our database does contain multiple tables that store the same object type it does become necessary to target a specific DbSet
                _context.reviews.Add(review); // Staging
                // OR _context.Add(review);
                _context.SaveChanges(); // Commit changes

                // return Json(review);
                return RedirectToAction("Reviews");
            }
            return View("Index");
        }
    }
}
