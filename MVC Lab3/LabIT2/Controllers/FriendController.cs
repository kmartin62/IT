using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabIT2.Models;

namespace LabIT2.Controllers
{
    public class FriendController : Controller
    {
        static List<FriendModel> lista = new List<FriendModel>();
       

        public ActionResult GetAllFriends()
        {
            return View(lista);
        }

        public ActionResult AddFriend()
        {
            FriendModel model = new FriendModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddFriend(FriendModel model)
        {
            if(!ModelState.IsValid)
            {
                return View("AddFriend", model);
            }

            lista.Add(model);
            return View("GetAllFriends", lista);
        }

        public ActionResult DeleteFriend(int id)
        {
            lista.RemoveAt(id);
            return View("GetAllFriends", lista);
        }

        public ActionResult EditFriend(int id)
        {
            var model = lista.ElementAt(id);
            model.Id = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditFriend(FriendModel model)
        {
            if(!ModelState.IsValid)
            {
                return View("EditFriend", model);
            }

            var forUpdate = lista.ElementAt(model.Id);
            forUpdate.FriendId = model.FriendId;
            forUpdate.Name = model.Name;
            forUpdate.City = model.City;

            return View("GetAllFriends", lista);


        }
    }
}