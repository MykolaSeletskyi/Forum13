using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PostController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public ActionResult Add(int Id, string Message)
        {
            Topic _topic = _db.Topics.Where(i => i.Id == Id).FirstOrDefault();
            if (string.IsNullOrEmpty(Message) || _topic==null)
            {
                return BadRequest();
            }
            _topic.Posts.Add(new Post()
            {
                Message = Message,
                CreatedDate = DateTime.Now,
                CreatorUserName = User.Identity.Name
            });
            _db.SaveChanges();
            return Redirect($"/Topic/Index/{Id}");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Post _post = _db.Posts.Where(i => i.Id == Id).FirstOrDefault();
            if (_post == null)
            {
                return NotFound();
            }
            return PartialView("_Edit", _post);
        }
        [HttpPost]
        public IActionResult Edit(int Id,string Message)
        {
            Post _post = _db.Posts.Where(i => i.Id == Id).FirstOrDefault();
            if (_post == null)
            {
                return NotFound();
            }
            if(_post.CreatorUserName!=User.Identity?.Name)
            {
                return BadRequest();
            }
            _post.Message = Message;
            _post.EditDate = DateTime.Now;
            _db.SaveChanges();
            return PartialView("_Item", _post);
        }
    }
}
    