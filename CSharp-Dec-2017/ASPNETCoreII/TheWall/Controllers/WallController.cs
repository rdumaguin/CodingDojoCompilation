using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Wall.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginRegistration.Controllers
{
    public class WallController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("dashboard")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("id") == null) // True if the user logged off, came back, and tried to refresh the browser!
                return RedirectToAction("Index", "Home");

            GrabViewBags();
            return View("Index");
        }

        [HttpPost("message")]
        public IActionResult Message(WallBundle post)
        {
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO messages (messages.content, messages.user_id, messages.created_at, messages.updated_at) VALUES ('{post.Message.Content}', {HttpContext.Session.GetInt32("id")}, NOW(), NOW())";
                DbConnector.Execute(query);
                return RedirectToAction("Index");
            }
            GrabViewBags();
            return View("Index");
        }

        [HttpPost("comment")]
        public IActionResult Comment(WallBundle post)
        {
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO comments (comments.content, comments.user_id, comments.message_id, comments.created_at, comments.updated_at) VALUES ('{post.Comment.Content}', {HttpContext.Session.GetInt32("id")}, {post.Comment.MessageId}, NOW(), NOW())";
                DbConnector.Execute(query);
                return RedirectToAction("Index");
            }
            GrabViewBags();
            return View("Index");
        }

        public void GrabViewBags()
        {
            ViewBag.User = DbConnector.Query($"Select first_name FROM users WHERE users.id = {HttpContext.Session.GetInt32("id")}")[0];
            ViewBag.Messages = GetMessages();
            ViewBag.Comments = GetComments();
        }

        public List<Dictionary<string, object>> GetMessages()
        {
            string query = $@"SELECT messages.id, messages.content, messages.created_at, users.first_name, users.last_name FROM messages
                JOIN users ON users.id = messages.user_id
                ORDER BY messages.created_at DESC";
            return DbConnector.Query(query);
        }

        public List<Dictionary<string, object>> GetComments()
        {
            string query = $@"SELECT comments.id, comments.content, comments.created_at, comments.message_id, users.first_name, users.last_name FROM comments
                JOIN users ON users.id = comments.user_id
                ORDER BY comments.created_at";
            return DbConnector.Query(query);
        }

    }
}
