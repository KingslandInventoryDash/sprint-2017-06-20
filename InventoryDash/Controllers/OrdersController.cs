using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryDash.DAL;
using InventoryDash.Models;

namespace InventoryDash.Controllers
{
    public class OrdersController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orderViewModel = prepareViewModel();
            return View(orderViewModel);
        }

        private object prepareViewModel()
        {
            if (db.Orders.Any())
            {
                return (from s in db.Ingredients
                        from so in db.Orders
                        .Where(orders => orders.IngredientID == s.ID)
                        select new OrderViewModel
                        {
                            MyID = so.MyID,
                            IngredientID = so.IngredientID,
                            Cost = so.Cost,
                            Portions = so.Portions,
                            PortionsRemaining = so.PortionsRemaining,
                            Date = so.Date,
                            ExpirationDate = so.ExpirationDate,
                            Notes = so.Notes,
                            Name = s.Name
                        }).ToList();
            }

            return new List<OrderViewModel>();
            
        }
   

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            //Get a list of Ingredients to pass along
            //var ingredientList = db.Ingredients.Select(ing => ing.Category != InventoryDash.Models.category.togo && ing.Category != InventoryDash.Models.category.beverage);
            var ingredientList = (from ing in db.Ingredients
                                  where ing.Category != InventoryDash.Models.category.togo && ing.Category != InventoryDash.Models.category.beverage
                                  select ing).ToList();

            ViewData["ingredientList"] = ingredientList;
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MyID,IngredientID,Cost,Portions,PortionsRemaining,Date,ExpirationDate,Notes")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MyID,IngredientID,Cost,Portions,PortionsRemaining,Date,ExpirationDate,Notes")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
