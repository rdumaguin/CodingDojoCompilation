using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BankAccounts.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Controllers
{
    public class AccountController : Controller
    {
        private MyContext _context;
        private User ActiveUser {
            get{return _context.Users.SingleOrDefault(user => user.Id == HttpContext.Session.GetInt32("UserId"));}
        }
        public AccountController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("account/{id}")]
        public IActionResult Account(int id)
        {
            // if(ActiveUser != null && ActiveUser.Id == id)
            if(ActiveUser?.Id == id && ActiveUser != null)
            {
                User thisUser = _context.Users.Include(u => u.Transactions).Where(u => u.Id == id).SingleOrDefault();
                thisUser.Transactions = thisUser.Transactions.OrderByDescending(t => t.CreatedAt).ToList();
                return View(thisUser);
            }
            return RedirectToAction("Login", "Home"); 
        }

        [HttpPost("transaction")]
        public IActionResult Transaction(float transaction)
        {
            if(ActiveUser != null)
            {
                if(transaction == 0)
                {
                    TempData["Error"] = "Please select an amount to deposit/withdraw!";
                    return RedirectToAction("Account", new { id = ActiveUser.Id });
                }
                else if(ActiveUser.Balance + transaction < 0)
                {
                    TempData["Error"] = "Insufficient funds!"; // Using TempData since we just need one error flashed to the View!
                    return RedirectToAction("Account", new { id = ActiveUser.Id });
                }
                else
                {
                    Transaction newTransaction = new Transaction()
                    {
                        User = ActiveUser,
                        Amount = transaction
                    };
                    ActiveUser.Transactions.Add(newTransaction);
                    ActiveUser.Balance += transaction;
                    _context.SaveChanges();
                    return RedirectToAction("Account", new { id = ActiveUser.Id });
                }
            }
            return RedirectToAction("Login", "Home"); 
        }
    }
}
