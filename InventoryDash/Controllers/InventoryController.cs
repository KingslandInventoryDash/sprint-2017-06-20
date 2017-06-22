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
using System.Globalization;

namespace InventoryDash.Controllers
{
    public class InventoryController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Weekly Inventory Data Entry
        public ActionResult Index()
        {

            int weekOfYear = GetCurrentWeekOfYear();

            var sandwichesViewModel = (from n in db.WeeklyInventorySandwiches
                                       from m in db.Sandwiches
                                        .Where(so => n.SandwichId == so.ID)
                                        .DefaultIfEmpty()
                                 where n.WeekId == weekOfYear
                                 select new WeeklyInventorySandwichesViewModel
                                 {
                                     WeekId = n.WeekId,
                                     SandwichId = m.ID,
                                     QuantityToGo = n.QuantityToGo,
                                     QuantityDineIn = n.QuantityDineIn,
                                     MealId = n.MealId,
                                     Cost = n.Cost,
                                     Income = n.Income,
                                     Name = m.Name,
                                     Price = m.Price,
                                     Meal = m.Meal
                                 }).ToList();

            //ViewData["sandwichesList"] = db.Sandwiches.ToList();
            return View(sandwichesViewModel);
        }

        // POST: Index page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "WeekId,SandwichId,MealId, QuantityToGo, QuantityDineIn")] WeeklyInventorySandwiches[] weeklyInventorySandwiches)
        {
            //Cycle through the array of Sandwich information and decide if an entry needs to be made.            
            for (int i = 0; i < weeklyInventorySandwiches.Count(); i++)
            {
                if(weeklyInventorySandwiches[i].QuantityDineIn != 0 || weeklyInventorySandwiches[i].QuantityToGo != 0)
                {
                    //Some quantity information was provided, so record the data.
                    db.WeeklyInventorySandwiches.Add(weeklyInventorySandwiches[i]);
                }
            }
            db.SaveChanges();
           
            return RedirectToAction("Index");
        }


        public int GetCurrentWeekOfYear()
        {
            //Getting the week number
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = DateTime.Today;
            System.Globalization.Calendar cal = dfi.Calendar;

            int weekOfYear = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            return weekOfYear;
        }
    }
}