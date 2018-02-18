using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVC.Models;

namespace MVC.Controllers
{
    public class DojodachiController : Controller
    {
        [HttpGet("")]
        public IActionResult Index() 
        {
            if(HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi") == null)
            {
                HttpContext.Session.SetObjectAsJson("Dojodachi", new Dojodachi());
            } // This is like our SAVE FILE that we are loading for our ViewBag
            TempData["Reaction"] = "You have a new Dojodachi!";
            ViewBag.GameStatus = "playing";
            ViewBag.Dojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");

            return View();
        }
        
        [HttpPost("action")]
        public IActionResult Action(string action) // 'action' is the form input 'name'
        {
            Dojodachi myDD = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
            ViewBag.GameStatus = "playing";
            Random rand = new Random();
            switch(action)
            {
                case "feed": 
                    if (myDD.Meals < 1)
                    {
                        TempData["Reaction"] = "No meals to feed!";
                    }
                    else // -1 Meal >> 75% chance of +5-10 Fullness
                    {
                        myDD.Meals -= 1;
                        if(rand.Next(4) > 0) // > 25%
                        {
                            int temp = rand.Next(5,11);
                            myDD.Fullness += temp;

                            TempData["Reaction"] = $"Yum! Fullness + {temp}";
                        }
                        else
                        {
                            TempData["Reaction"] = "Yuck!";
                        }
                    }
                    break;
                case "play":
                    if (myDD.Energy < 5 )
                    {
                        TempData["Reaction"] = "Need 5 energy!";
                    }
                    else // -5 Energy >> 75% chance of +5-10 Happiness
                    {
                        myDD.Energy -= 5;
                        if(rand.Next(4) > 0) // > 25%
                        {
                            int temp = rand.Next(5,11);
                            myDD.Happiness += temp;

                            TempData["Reaction"] = $"That was fun! Happiness increased by {temp}!";
                        }
                        else
                        {
                            TempData["Reaction"] = $"That wasn't so fun..";
                        }
                    }
                    break;
                case "work":
                    if (myDD.Energy < 5 )
                    {
                        TempData["Reaction"] = "Need 5 energy!";
                    }
                    else // -5 Energy >> +1-3 Meals
                    {
                        myDD.Energy -= 5;
                        int temp = rand.Next(1,4);
                        myDD.Meals += temp;

                        TempData["Reaction"] = $"Meals increased by {temp}!";
                    }
                    break;
                case "sleep": // -5 Fullness & Happiness >> +15 Energy
                    myDD.Energy += 15;
                    myDD.Fullness -= 5;
                    myDD.Happiness -= 5;

                    TempData["Reaction"] = $"Energy increased by 15!";
                    break;
                default:
                    // default is used if there isn't a matching case
                    TempData["Reaction"] = "Action input error found!";
                    break;
            }

            if(myDD.Energy >= 100 && myDD.Fullness >= 100 && myDD.Happiness >= 100)
            {
                TempData["Reaction"] = "Congratulations! You won!";
                ViewBag.GameStatus = "gameover";
            }
            else if(myDD.Fullness <= 0 || myDD.Happiness <= 0)
            {
                TempData["Reaction"] = "Your Dojodachi has passed away...";
                ViewBag.GameStatus = "gameover";
            }

            HttpContext.Session.SetObjectAsJson("Dojodachi", myDD);
            ViewBag.Dojodachi = myDD; // This way we don't have to redirect to Index() to set it.

            return View("Index");
        }

        [HttpGet("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
