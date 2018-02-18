using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LostInTheWoods.Factories;
using LostInTheWoods.Models;

namespace LostInTheWoods.Controllers
{
    public class TrailController : Controller
    {
        private readonly TrailFactory trailFactory;
        public TrailController()
        {
            // Instantiate a UserFactory object that is immutable (READONLY)
            // This establishes the initial DB connection for us.
            trailFactory = new TrailFactory();
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            // We can call upon the methods of the userFactory directly now.
            ViewBag.Trails = trailFactory.FindAll();
            return View();
        }
        [HttpGet("new")]
        public IActionResult NewTrail()
        {
            return View("NewTrail");
        }
        [HttpPost("create")]
        public IActionResult CreateTrail(Trail trail)
        {
            if(ModelState.IsValid)
            {
                trailFactory.Add(trail);
                // return Json(trail); // For debugging purposes! No return required.
            }
            return View("NewTrail");
        }
        [HttpGet("show/{id}")]
        public IActionResult ShowTrail(int id)
        {
            ViewBag.Trail = trailFactory.GetInfo(id);
            return View($"Show");
        }
    }
}
