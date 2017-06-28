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
    public class WeeklyInventoryToGosController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Weekly Drink Sales Data Entry
        public ActionResult Index()
        {

            int weekOfYear = GetCurrentWeekOfYear();
            DateTime dateNow = DateTime.Now;
            int currentYear = dateNow.Year;
            ViewData["weekOfYear"] = weekOfYear;
            ViewData["startingYear"] = 2016;
            ViewData["selectedYear"] = currentYear;

            var togosViewModel = GetViewModel(currentYear, weekOfYear);


            return View(togosViewModel);
        }



        [HttpGet]
        public ActionResult IndexLoadWeekGet()
        {
            int weekSelected = Convert.ToInt32(TempData["selectedWeek"]);
            int yearSelected = Convert.ToInt32(TempData["selectedYear"]);

            ViewData["weekOfYear"] = weekSelected;
            ViewData["startingYear"] = 2016;
            ViewData["selectedYear"] = yearSelected;

            var togosViewModel = GetViewModel(yearSelected, weekSelected);


            return View("Index", togosViewModel);
        }



        [HttpPost]
        public ActionResult IndexLoadWeek()
        {
            int weekSelected = Convert.ToInt32(Request.Form["weekSelect"]);
            int yearSelected = Convert.ToInt32(Request.Form["yearSelect"]);

            ViewData["weekOfYear"] = weekSelected;
            ViewData["startingYear"] = 2016;
            ViewData["selectedYear"] = yearSelected;

            var togosViewModel = GetViewModel(yearSelected, weekSelected);


            return View("Index", togosViewModel);
        }


        // POST: Index page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ID, WeekId, Year, ToGoId, QuantityToGo, QuantityDineIn, Cost, Income")] WeeklyInventoryToGos[] weeklyInventoryToGos)
        {
            int weekSelected = Convert.ToInt32(Request.Form["weekSelect"]);
            int yearSelected = Convert.ToInt32(Request.Form["yearSelect"]);

            int weekOfYear = weeklyInventoryToGos[0].WeekId;
            int Year = weeklyInventoryToGos[0].Year;
            //Cycle through the array of Sandwich information and decide if an entry needs to be made.            

            for (int i = 0; i < weeklyInventoryToGos.Count(); i++)
            {

                //Calculate the cost and income values
                int totalQty = Convert.ToInt32(weeklyInventoryToGos[i].QuantityDineIn) + Convert.ToInt32(weeklyInventoryToGos[i].QuantityToGo);
                weeklyInventoryToGos[i].Cost = Convert.ToDecimal(CalculateToGoCost(weeklyInventoryToGos[i].ToGoId, totalQty));
                weeklyInventoryToGos[i].Income = Convert.ToDecimal(CalculateToGoIncome(weeklyInventoryToGos[i].ToGoId, totalQty));


                //Determine if a record already exists - 
                if (weeklyInventoryToGos[i].ID != 0)
                {
                    //Yes, then update the record.
                    var togoIdToQuery = weeklyInventoryToGos[i].ID;
                    var record = db.WeeklyInventoryToGos.SingleOrDefault(x => x.ID == togoIdToQuery);
                    record.QuantityDineIn = weeklyInventoryToGos[i].QuantityDineIn;
                    record.QuantityToGo = weeklyInventoryToGos[i].QuantityToGo;
                    record.Cost = weeklyInventoryToGos[i].Cost;
                    record.Income = weeklyInventoryToGos[i].Income;
                    record.WeekId = weeklyInventoryToGos[i].WeekId;
                    record.Year = weeklyInventoryToGos[i].Year;
                    db.SaveChanges();
                }
                else
                {
                    //No, add the record.
                    db.WeeklyInventoryToGos.Add(weeklyInventoryToGos[i]);
                    db.SaveChanges();
                }
                
            }


            TempData["selectedYear"] = yearSelected;
            TempData["selectedWeek"] = weekSelected;
            return RedirectToAction("IndexLoadWeekGet"); // Stored year and week info in temp data, have to go to a get based action next.

        }

        private double? CalculateToGoIncome(int togoId, int totalQty)
        {
            //Use the item ID to query the item model to get the current price
            var togoList = from s in db.Ingredients
                           .Where(togos => togos.Category == InventoryDash.Models.category.togo)
                             where s.ID == togoId
                             select s;
            foreach (var a in togoList)
            {
                return a.Price * totalQty;
            }
            return null;
        }

        private double? CalculateToGoCost(int togoId, int totalQty)
        {
            //Get the cost of the togo from the Ingredients table / helper method.
            var togoList = from s in db.Ingredients
                           .Where(togos => togos.Category == InventoryDash.Models.category.togo)
                           where s.ID == togoId
                           select s;
            foreach (var a in togoList)
            {
                return (a.Price / a.NumPortions) * totalQty;
            }
            return null;
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



        private object GetViewModel(int currentYear, int weekOfYear)
        {
            return (from s in db.Ingredients
                    .Where(togos => togos.Category == InventoryDash.Models.category.togo)
                    from so in db.WeeklyInventoryToGos
                    .Where(orders => s.ID == orders.ToGoId && orders.WeekId == weekOfYear && orders.Year == currentYear)
                    .DefaultIfEmpty()
                    select new WeeklyInventoryToGosViewModel
                    {
                        ID = so.ID,
                        WeekId = so.WeekId,
                        Year = so.Year,
                        ToGoId = s.ID,
                        QuantityToGo = so.QuantityToGo,
                        QuantityDineIn = so.QuantityDineIn,
                        Cost = so.Cost,
                        Income = so.Income,
                        Name = s.Name,
                        Price = s.Price,
                    }).ToList();
        }

    }
}