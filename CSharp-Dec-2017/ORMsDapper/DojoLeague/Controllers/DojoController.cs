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
    public class DojoController : Controller
    {
        private MyContext _context;
        public DojoController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("dojo")]
        public IActionResult Index()
        {
            var DojoIndex = new DojoIndex()
            {
                Dojos = _context.Dojos.ToList()
            };
            return View(DojoIndex);
        }

        [HttpGet("dojo/{id}")]
        public IActionResult Show(int id)
        {
            var ShowDojo = new ShowDojo()
            {
                Dojo = _context.Dojos.Include(d => d.Members).SingleOrDefault(d => d.DojoId == id),
                RogueNinjas = _context.Ninjas.Where(n => n.DojoId == 1).ToList(),
            };
            return View(ShowDojo);
        }

        [HttpPost("dojos/create")]
        public IActionResult Create(DojoIndex model)
        {
            Dojo dojo = model.NewDojo;
            if(ModelState.IsValid)
            {
                var NewDojo = new Dojo()
                {
                    Name = dojo.Name,
                    Location = dojo.Location,
                    AdditionalInfo = dojo.AdditionalInfo,
                };

                _context.Add(NewDojo);
                // OR _context.Dojos.Add(NewDojo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index", new DojoIndex(){
                Dojos = _context.Dojos.ToList(),
                NewDojo = dojo
            });
        }

    }
}