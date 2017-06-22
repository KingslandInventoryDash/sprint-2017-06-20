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
using System.Dynamic;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Web.UI.WebControls;

namespace InventoryDash.Controllers
{
    public class InventoryController : Controller
    {
        private InventoryContext db = new InventoryContext();
        private WeeklyInventoryContext weeklyDb = new WeeklyInventoryContext();



        // GET: Weekly Inventory Data Entry
        public ActionResult Index()
        {   

            return View(db.Sandwiches.ToList());
        }

        // POST: Index page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(WeeklyInventorySandwiches weeklyInventorySandwiches)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weeklyInventorySandwiches).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}