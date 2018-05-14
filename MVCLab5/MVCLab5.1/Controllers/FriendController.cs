using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLab5._1.Models;

namespace MVCLab5._1.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
        //static List<FriendModel> lista = new List<FriendModel>()
        //{
        //    new FriendModel
        //    {
        //        FriendId = 2,
        //        Name = "Martin",
        //        Place = "Radovis"
        //    }            
        //};

        private FriendDbContext Friends;

        public FriendController()
        {
            Friends = new FriendDbContext();
        }



        public ActionResult Index()
        {
            return View(Friends.friends.ToList());
        }

        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult AddFriend()
        {
            FriendModel model = new FriendModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddFriend(FriendModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("AddFriend", model);
            }

            Friends.friends.Add(model);
            Friends.SaveChanges();

            return RedirectToAction("Index", "Friend");
        }

        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult DeleteFriend(int id)
        {
            Friends.friends.Remove(Friends.friends.FirstOrDefault(z => z.Id == id));
            Friends.SaveChanges();
            return View("Index", Friends.friends.ToList());
        }
        
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Manager)]
        public ActionResult EditFriend(int id)
        {
            var model = Friends.friends.FirstOrDefault(z => z.Id == id);
            model.Id = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditFriend(FriendModel model)
        {
            FriendModel fr = Friends.friends.FirstOrDefault(f => f.Id == model.Id);

            if (!ModelState.IsValid)
            {
                return View("EditFriend", fr);
            }

            Friends.friends.Remove(fr);
            Friends.friends.Add(model);
            Friends.SaveChanges();
            return RedirectToAction("Index", "Friend");

        }

        protected override void Dispose(bool disposing)
        {
            Friends.Dispose();
        }
    }
}