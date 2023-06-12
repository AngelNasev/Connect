using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Connect.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        Connect.Models.DbConnect _db = new Connect.Models.DbConnect();
        // GET: Search
        public ActionResult Index(string searchTerm)
        {
            var model = _db.Users.OrderBy(u => u.Username)
                .Where(u => searchTerm == null || u.Username.StartsWith(searchTerm))
                .Take(10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Users",model);
            }
            return View(model);
        }

        public ActionResult Autocomplete(string term)
        {
            var model = _db.Users.OrderBy(u => u.Username)
                .Where(u => u.Username.StartsWith(term))
                .Take(10).Select(u => new
                {
                    label = u.Username,
                });
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}