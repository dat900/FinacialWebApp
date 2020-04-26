using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinacialWebApp.Models.DAO;

namespace FinacialWebApp.Controllers
{
    public class IncomesController : Controller
    {
        // GET: Income
        public ActionResult Incomes()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IncomeByYear()
        {
            var income = Income.GetIncome();
            var result = from i in income
                         orderby i.Month
                         group i by i.Year into gb
                         select new
                         {
                             _year = gb.Key.ToString(),
                             _income = gb.Sum(n=>n.Money)
                         };
            var labels = result.Select(n => n._year);
            var money = result.Select(n => n._income);
            return Json(new { labels, money }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult IncomeByMonth()
        {
            var income = Income.GetIncome();
            var result = from i in income
                         orderby i.Month
                         group i by i.Month into sp

                         select new
                         {
                             month = sp.Key.ToString(),
                             money = sp.Sum(n => n.Money)
                         };
            var labels = result.Select(n => n.month);
            var money = result.Select(n => n.money);
            return Json(new { labels, money }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddIncome(FormCollection formCollection)
        {
            var date = DateTime.Parse(formCollection["date"].ToString());
            var income = int.Parse(formCollection["money"].ToString());
            var note = formCollection["note"].ToString();
            Income.AddNewIncome(date, income, note);
            return View();
        }
    }
}