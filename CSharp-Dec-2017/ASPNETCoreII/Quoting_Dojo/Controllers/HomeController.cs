using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using System.Linq;
using Quoting_Dojo.Models;

namespace Quoting_Dojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("quotes")]
        public IActionResult Quotes(Quote quote)
        {
            // var AnonObject = new {
            //                     Name = name,
            //                     Quote = quote,
            //                 };
            // return Json(AnonObject);
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO quotes (author, content, created_at, updated_at) VALUES ('{quote.author}', '{quote.content}', NOW(), NOW())";
                DbConnector.Execute(query);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        
        [HttpGet("quotes")]
        public IActionResult Quotes()
        {
            var quotes = DbConnector.Query("SELECT * FROM quotes");    
            quotes = quotes.OrderByDescending(quote => quote["created_at"]).ToList(); // OrderBy created_at                
            foreach(var quote in quotes)
            {
                DateTime created_at = (DateTime)quote["created_at"]; // Unboxing object type to DT
                string formatted_created_at = String.Format("{0:h:mm tt MMMM d yyyy}", created_at);
                quote["created_at"] = formatted_created_at;
            }
            ViewBag.Quotes = quotes;
            return View("Quotes");
        }
    }
}
