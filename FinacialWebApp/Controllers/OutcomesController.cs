using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using FinacialWebApp.Models;
using FinacialWebApp.Models.DAO;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Newtonsoft.Json;

namespace FinacialWebApp.Controllers
{
    public class OutcomesController : Controller
    {
        // GET: Outcomes
        public ActionResult Outcomes()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OutcomeByMonth()
        {
            var outcome = Outcome.GetNoteOutcomes();
            var result = from o in outcome
                          orderby o.date
                          group o by o.date.Month into sp
                          select new
                          {
                              _month = sp.Key.ToString(),
                              _outcome = sp.Sum(n => n.money)
                          };
            var labels = result.Select(n=>n._month).ToArray();
            var money = result.Select(n => n._outcome).ToArray();
            return Json(new { labels, money }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult OutcomeByYear()
        {
            var outcome = Outcome.GetNoteOutcomes();
            var result = from o in outcome
                          orderby o.date
                          group o by o.date.Year into sp
                          select new
                          {
                              label = sp.Key.ToString(),
                              money = sp.Sum(n => n.money)
                          };
            var labels = result.Select(n => n.label);
            var money = result.Select(n => n.money);
            return Json(new { labels, money }, JsonRequestBehavior.AllowGet);
        }
        public List<String> Mapdata(IEnumerable<int> labels)
        {
            Dictionary<int, string> label_map = MapTypeName.ReadLabelName();
            List<string> label_name = new List<string>();
            foreach(var label in labels)
            {
                label_name.Add(label_map[label]);
            }
            return label_name;
        }
        [HttpPost]
        public ActionResult OutcomeByType()
        {
            var outcome = Outcome.GetNoteOutcomes();
            var result = from o in outcome
                              orderby o.type
                              group o by o.type into p
                              select new 
                              {
                                  label = p.Key,
                                  money = p.Sum(n => n.money)
                              };
            
            var labels = Mapdata(result.Select(n => n.label));
            var money = result.Select(n => n.money);
            return Json(new { labels, money }, JsonRequestBehavior.AllowGet);
        }
    }
}