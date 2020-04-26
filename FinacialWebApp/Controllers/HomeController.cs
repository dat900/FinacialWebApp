using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinacialWebApp.Models;
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
        [HttpPost]
        public ActionResult Login(FormCollection form, string url)
        {
            string username = form["username"].ToString();
            string password = form["password"].ToString();
            Users user = Users.ReadData();
            if (user.username != username || user.password != password)
            {
                return Redirect(url);
            }
            return RedirectToAction("Index", "Income");
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