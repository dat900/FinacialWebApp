using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinacialWebApp.Models.DAO;
using Newtonsoft.Json.Linq;

namespace FinacialWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IncomeByMonth()
        {
            var (month, money) = Income.GetIncomeByMonth();
            ViewBag.month = month;
            ViewBag.money = money;
            return PartialView();
        }       
        public ActionResult OutcomeByMonth()
        {
            var (month, money) = Outcome.GetOutcomesByMonth();
            ViewBag.month = month;
            ViewBag.money = money;
            return PartialView();
        }
        public ActionResult Outcomes()
        {
            return View();
        }
        public ActionResult AddNewIncome_Outcome()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}