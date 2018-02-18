using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class WeddingPlannerController : Controller
    {
        private MyContext _context;
        private User ActiveUser{
            get{return _context.Users.SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));}
        } 
        public WeddingPlannerController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("wedding/dashboard")]
        public IActionResult Index()
        {
            if(ActiveUser == null)
                return RedirectToAction("Index", "Home");

            ViewBag.ActiveUser = ActiveUser;
            var WeddingPlannerIndex = new WeddingPlannerIndex()
                    {
                        Weddings = _context.Weddings_Planned
                            .Include(w => w.RSVPdGuests)
                            .ToList(),

                    };
            return View(WeddingPlannerIndex);
        }

        [HttpGet("wedding/new")]
        public IActionResult New()
        {
            if(ActiveUser == null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpGet("wedding/show/{id}")]
        public IActionResult Show(int id)
        {
            if(ActiveUser == null)
                return RedirectToAction("Index", "Home");
            var ShowWedding = new ShowWedding()
                    {
                        Wedding = _context.Weddings_Planned
                            .Include(w => w.RSVPdGuests)
                                .ThenInclude(g => g.Guest)
                            .SingleOrDefault(w => w.WeddingId == id)
                    };
            return View(ShowWedding);
        }

        [HttpGet("wedding/delete/{id}")]
        public IActionResult Delete(int id)
        {
            if(ActiveUser == null)
                return RedirectToAction("Index", "Home");
            WeddingPlanned retrievedWedding = _context.Weddings_Planned.SingleOrDefault(w => w.WeddingId == id);
            _context.Weddings_Planned.Remove(retrievedWedding);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("wedding/rsvp/{id}")]
        public IActionResult Rsvp(int id)
        {
            if(ActiveUser == null)
                return RedirectToAction("Index", "Home");
            RSVP rsvp = new RSVP()
            {
                UserId = ActiveUser.UserId,
                WeddingId = id
            };
            _context.RSVPs.Add(rsvp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("wedding/unRsvp/{id}")]
        public IActionResult UnRsvp(int id)
        {
            if(ActiveUser == null)
                return RedirectToAction("Index", "Home");
            RSVP retrievedRSVP = _context.RSVPs.SingleOrDefault(r => r.UserId == ActiveUser.UserId && r.WeddingId == id);
            _context.RSVPs.Remove(retrievedRSVP);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpPost("wedding/create")]
        public IActionResult Create(WeddingPlanned model)
        {
            if(ActiveUser == null)
                return RedirectToAction("Index", "Home");
            if(ModelState.IsValid)
            {
                // Create WeddingPlanned
                WeddingPlanned wedding = new WeddingPlanned()
                {
                    WedderOne = model.WedderOne,
                    WedderTwo = model.WedderTwo,
                    Date = model.Date,
                    Address = model.Address,
                    Planner = ActiveUser
                    // created_at = DateTime.Now, // Set in the constructor()
                    // updated_at = DateTime.Now, // Set in the constructor()
                };

                // Entity Framework is smart enough to look for a DbSet that contains the appropriate object type and save the new entry there. If our database does contain multiple tables that store the same object type it does become necessary to target a specific DbSet
                _context.Weddings_Planned.Add(wedding); // Staging
                // OR _context.Add(wedding);
                _context.SaveChanges(); // Commit changes
                // return Json(wedding);
                return RedirectToAction("Index");
            }
            return View("New");
        }
    }
}
