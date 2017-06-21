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

        // POST: Index page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ID,MenuItem,Qty")] DailyInventory dailyInventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailyInventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dailyInventory);
        }
    }
}