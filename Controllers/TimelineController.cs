using Microsoft.AspNet.Identity;
using Connect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Connect.Controllers
{
    [Authorize]
    public class TimelineController : Controller
    {
        Connect.Models.DbConnect _db = new Connect.Models.DbConnect();
        // GET: Timeline
        public ActionResult Index()
        {
            var model = _db.Posts.OrderByDescending(p => p.CreatedAt)
                .Select(p => new TimelineVM
                {
                    Id = p.Id,
                    Text = p.Text,
                    AuthorId = p.AuthorId,
                    CreatedAt = p.CreatedAt,
                    Username = _db.Users.Where(u => u.UserId == p.AuthorId).FirstOrDefault().Username
                });
            return View(model);
        }

        // GET: Timeline/Create
        public ActionResult Create()
        {
            CreatePost post = new CreatePost();
            return View(post);
        }

        // POST: Timeline/Create
        [HttpPost]
        public ActionResult Create(CreatePost model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create",model);
            }
            model.AuthorId = User.Identity.GetUserId();
            model.CreatedAt = DateTime.Now;
            _db.Posts.Add(model);
            _db.Users.Single(i => i.UserId == model.AuthorId).Posts.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index","Timeline");
        }

        // GET: Timeline/Edit/5
        public ActionResult Edit(int id)
        {
            //var post = Posts.ElementAt(id);
            var post = _db.Posts.Single(i => i.Id == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Timeline/Edit/5
        [HttpPost]
        public ActionResult Edit(CreatePost model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index","Timeline",model);
            }
            var post = _db.Posts.Single(i => i.Id == model.Id);
            TryUpdateModel(post);
            _db.SaveChanges();
            return RedirectToAction("Index", "Timeline"); 
        }

        // GET: Timeline/Delete/5
        public ActionResult Delete(int id)
        {
            var post = _db.Posts.Single(i => i.Id==id);
            _db.Posts.Remove(post);
            _db.SaveChanges();
            return RedirectToAction("Index", "Timeline");
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
