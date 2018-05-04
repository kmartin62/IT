using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVCLab4.Models;

namespace MVCLab4.Controllers
{
    public class FriendApiController : ApiController
    {
        private FriendDbContext db = new FriendDbContext();

        // GET: api/FriendApi
        public IQueryable<FriendModel> Getfriends()
        {
            return db.friends;
        }

        // GET: api/FriendApi/5
        [ResponseType(typeof(FriendModel))]
        public IHttpActionResult GetFriendModel(int id)
        {
            FriendModel friendModel = db.friends.Find(id);
            if (friendModel == null)
            {
                return NotFound();
            }

            return Ok(friendModel);
        }

        // PUT: api/FriendApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFriendModel(int id, FriendModel friendModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != friendModel.Id)
            {
                return BadRequest();
            }

            db.Entry(friendModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FriendApi
        [ResponseType(typeof(FriendModel))]
        public IHttpActionResult PostFriendModel(FriendModel friendModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.friends.Add(friendModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = friendModel.Id }, friendModel);
        }

        // DELETE: api/FriendApi/5
        [ResponseType(typeof(FriendModel))]
        public IHttpActionResult DeleteFriendModel(int id)
        {
            FriendModel friendModel = db.friends.Find(id);
            if (friendModel == null)
            {
                return NotFound();
            }

            db.friends.Remove(friendModel);
            db.SaveChanges();

            return Ok(friendModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FriendModelExists(int id)
        {
            return db.friends.Count(e => e.Id == id) > 0;
        }
    }
}