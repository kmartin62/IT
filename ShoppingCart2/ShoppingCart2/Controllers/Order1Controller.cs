using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingCart2.Models;

namespace ShoppingCart2.Controllers
{
    public class Order1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Order1
        public ActionResult Index()
        {
            return View(db.Orders1.ToList());
        }

        // GET: Order1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order1 order1 = db.Orders1.Find(id);
            if (order1 == null)
            {
                return HttpNotFound();
            }
            return View(order1);
        }

        // GET: Order1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,OrderKey,Username,FirstName,LastName,Address,City,State,PostalCode,Country,Phone,Email,Total,OrderDate")] Order1 order1)
        {
            if (ModelState.IsValid)
            {
                List<Cart> lstCart = (List<Cart>)Session["Cart"];
                order1.OrderDate = DateTime.Now;
                order1.Total = Session["total"].ToString();
                var user = User.Identity.Name;
                order1.Email = user;
                db.Orders1.Add(order1);
                db.SaveChanges();

                foreach(Cart cart in lstCart)
                {
                    OrderDetails1 orderDetails = new OrderDetails1
                    {
                        OrderId = order1.OrderId,
                        BookId = cart.book.Id,
                        Quantity = cart.Quantity,
                        Price = cart.book.Price.ToString()
                    };

                    db.OrderDetails1.Add(orderDetails);
                    db.SaveChanges();
                }

                Session.Remove("Cart");

                return RedirectToAction("Index");
            }

            return View(order1);
        }

        // GET: Order1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order1 order1 = db.Orders1.Find(id);
            if (order1 == null)
            {
                return HttpNotFound();
            }
            return View(order1);
        }

        // POST: Order1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,OrderKey,Username,FirstName,LastName,Address,City,State,PostalCode,Country,Phone,Email,Total,OrderDate")] Order1 order1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order1);
        }

        // GET: Order1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order1 order1 = db.Orders1.Find(id);
            if (order1 == null)
            {
                return HttpNotFound();
            }
            return View(order1);
        }

        // POST: Order1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order1 order1 = db.Orders1.Find(id);
            db.Orders1.Remove(order1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
