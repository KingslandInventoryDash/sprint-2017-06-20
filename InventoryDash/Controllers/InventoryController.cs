using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryDash.Models;
using System.Data.Entity;
using InventoryDash.DAL;

namespace InventoryDash.Controllers
{
    public class InventoryController : Controller
    {
        private InventoryContext db = new InventoryContext();

        //List<int> QtyDineIn = new List<int>();

        // GET: Log
        public ActionResult Index()
        {
            return View(db.Sandwiches.ToList());
        }

        // POST: Meats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Price")] Meat meat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meat);
        }*/
    }
}