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
    public class UserProfileController : Controller
    {
        Connect.Models.DbConnect _db = new Connect.Models.DbConnect();
        
        // GET: UserProfile/UserId
        public ActionResult Index([Bind(Prefix = "id")]string UserId)
        {
            var Friends = new List<string>();
            var co = _db.EstablishedConnections.Where(x => x.User1Id == UserId || x.User2Id == UserId);
            foreach (var conn in co)
            {
                Friends.Add(conn.User1Id == UserId ? conn.User2Id : conn.User1Id);
            }
            var Pending = new List<string>();
            var pe = _db.PendingRequests.Where(x => x.User1Id == UserId || x.User2Id == UserId);
            foreach (var pend in pe)
            {
                Pending.Add(pend.User1Id == UserId ? pend.User2Id : pend.User1Id);
            }
            var model = _db.Users.FirstOrDefault(x => x.UserId==UserId);
            ProfileVM profile = new ProfileVM();
            profile.UserId = model.UserId;
            profile.Username = model.Username;
            profile.DateOfBirth = model.DateOfBirth;
            profile.DateCreated = model.DateCreated;
            profile.Bio = model.Bio;
            profile.NumConnections = _db.EstablishedConnections.Where(x => x.User1Id == UserId || x.User2Id == UserId).Count();
            profile.Posts = _db.Posts.Where(x => x.AuthorId == profile.UserId).OrderByDescending(p => p.CreatedAt);
            profile.Friends = Friends;
            profile.Pending = Pending;
            return View(profile);
        }

        // GET: UserProfile/Edit/UserId
        public ActionResult Edit([Bind(Prefix = "id")] string UserId)
        {
            var profile = _db.Users.FirstOrDefault(x => x.UserId == UserId);
            return View(profile);
        }

        // POST: UserProfile/Edit/
        [HttpPost]
        public ActionResult Edit(User model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", "UserProfile", model);
            }
            var u = _db.Users.FirstOrDefault(x => x.UserId == model.UserId);
            TryUpdateModel(u);
            _db.SaveChanges();
            return RedirectToAction("Index/"+model.UserId, "UserProfile");
        }

        public ActionResult Connections([Bind(Prefix = "id")] string UserId)
        {
            var pend = _db.PendingRequests.Where(x => x.User1Id == UserId || x.User2Id == UserId)
                .Select(p => new PendingVM
                {
                    ConnectionId = p.ConnectionId,
                    UserId = p.User1Id == UserId ? p.User1Id : p.User2Id,
                    FriendId = p.User2Id == UserId ? p.User1Id : p.User2Id,
                    FriendUsername = p.User1Id == UserId ? _db.Users.Where(u => u.UserId == p.User2Id).FirstOrDefault().Username :
                    _db.Users.Where(u => u.UserId == p.User1Id).FirstOrDefault().Username,
                    FromMe = p.User1Id == UserId ? true : false
                });
            var conn = _db.EstablishedConnections.Where(x => x.User1Id == UserId || x.User2Id == UserId)
                .Select(c => new ConnectionVM
                {
                    ConnectionId = c.ConnectionId,
                    UserId = c.User1Id == UserId ? c.User1Id : c.User2Id,
                    FriendId = c.User2Id == UserId ? c.User1Id : c.User2Id,
                    FriendUsername = c.User1Id == UserId ? _db.Users.Where(u => u.UserId == c.User2Id).FirstOrDefault().Username :
                    _db.Users.Where(u => u.UserId == c.User1Id).FirstOrDefault().Username
                });
            PendingAndEstablishedVM model = new PendingAndEstablishedVM();
            model.UserId = UserId;
            model.PendingVM = pend;
            model.ConnectionVM = conn;
            return View(model);
        }

        // GET: UserProfile/AcceptPending/ConnectionId
        public ActionResult AcceptPending(int ConnectionId, string UserId)
        {
            var pend = _db.PendingRequests.Single(p => p.ConnectionId == ConnectionId);
            Connection conn = new Connection();
            conn.User1Id=pend.User1Id;
            conn.User2Id=pend.User2Id;
            _db.PendingRequests.Remove(pend);
            _db.EstablishedConnections.Add(conn);
            _db.SaveChanges();

            return RedirectToAction("Connections/" + UserId, "UserProfile");
        }

        // GET: UserProfile/DeclinePending/ConnectionId
        public ActionResult DeclinePending(int ConnectionId, string UserId)
        {
            var pend = _db.PendingRequests.Single(p => p.ConnectionId == ConnectionId);
            _db.PendingRequests.Remove(pend);
            _db.SaveChanges();

            return RedirectToAction("Connections/" + UserId, "UserProfile");
        }
        // GET: UserProfile/DeclinePending/ConnectionId
        public ActionResult RemoveConnection(int ConnectionId, string UserId)
        {
            var conn = _db.EstablishedConnections.Single(p => p.ConnectionId == ConnectionId);
            _db.EstablishedConnections.Remove(conn);
            _db.SaveChanges();

            return RedirectToAction("Connections/" + UserId, "UserProfile");
        }

        public ActionResult SendRequest([Bind(Prefix = "id")] string UserId)
        {
            PendingRequests pending = new PendingRequests();
            pending.User1Id = User.Identity.GetUserId();
            pending.User2Id = UserId;
            _db.PendingRequests.Add(pending);
            _db.SaveChanges();
            return RedirectToAction("Index/" + UserId, "UserProfile");
        }
    }
}
