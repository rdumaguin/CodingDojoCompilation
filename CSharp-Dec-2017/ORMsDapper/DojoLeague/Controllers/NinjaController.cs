using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoLeague.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DojoLeague.Controllers
{
    public class NinjaController : Controller
    {
        private MyContext _context;
        public NinjaController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            // ViewBag.Ninjas = _context.Ninjas.Include(n => n.Dojo).ToList();
            var NinjaIndex = new NinjaIndex()
            {
                Ninjas = _context.Ninjas.Include(n => n.Dojo).ToList(),
                Dojos = _context.Dojos.ToList()
            };
            // List<Ninja> Ninjas = _context.Ninjas.ToList();
            return View(NinjaIndex);
        }

        [HttpPost("")]
        public IActionResult Index(NinjaIndex model)
        {
            
            // List<Ninja> Ninjas = _context.Ninjas.ToList();
            return View(model);
        }
        
        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            return View(_context.Ninjas.Include(n => n.Dojo).SingleOrDefault(n => n.NinjaId == id)); // Passing a Ninja.cs model
        }

        [HttpPost("ninjas/create")]
        public IActionResult Create(NinjaIndex model)
        {
            Ninja ninja = model.NewNinja;
            if(ModelState.IsValid)
            {
                var NewNinja = new Ninja()
                {
                    Name = ninja.Name,
                    Level = ninja.Level,
                    DojoId = ninja.DojoId,
                    Description = ninja.Description
                };

                _context.Add(NewNinja);
                // OR _context.Ninjas.Add(NewNinja);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index", new NinjaIndex(){
                Ninjas = _context.Ninjas.Include(n => n.Dojo).ToList(),
                Dojos = _context.Dojos.ToList(),
                NewNinja = ninja
            });
        }
        
        [HttpGet("banish/{ninja_id}/{dojo_id}")]
        public IActionResult Banish(int ninja_id, int dojo_id)
        {
            Ninja RetrievedNinja = _context.Ninjas.SingleOrDefault(n => n.NinjaId == ninja_id);
            RetrievedNinja.DojoId = 1;
            Dojo RetrievedDojo = _context.Dojos.SingleOrDefault(d => d.DojoId == dojo_id);
            RetrievedDojo.Members.Remove(RetrievedNinja);
            _context.SaveChanges();
            return RedirectToAction("Show", "Dojo", new {id = dojo_id});
        }

        [HttpGet("recruit/{ninja_id}/{dojo_id}")]
        public IActionResult Recruit(int ninja_id, int dojo_id)
        {
            Ninja RetrievedNinja = _context.Ninjas.SingleOrDefault(n => n.NinjaId == ninja_id);
            RetrievedNinja.DojoId = dojo_id;
            Dojo RetrievedDojo = _context.Dojos.SingleOrDefault(d => d.DojoId == dojo_id);
            RetrievedDojo.Members.Add(RetrievedNinja);
            _context.SaveChanges();
            return RedirectToAction("Show", "Dojo", new {id = dojo_id});
        }
        
        [HttpGet("dojos/register")]
        public IActionResult RegisterDojo()
        {
            return View();
        }

    }
}