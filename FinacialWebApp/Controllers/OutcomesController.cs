using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinacialWebApp.Models;
using FinacialWebApp.Models.DAO;

namespace FinacialWebApp.Controllers
{
    public class OutcomesController : Controller
    {
        // GET: Outcomes
        public ActionResult Outcomes()
        {
            return View();
        }
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
            ViewBag.month = result.Select(n => n._month);
            ViewBag.outcome = result.Select(n => n._outcome);
            return PartialView();
        }
        public ActionResult OutcomeByYear()
        {
            var outcome = Outcome.GetNoteOutcomes();
            var result = from o in outcome
                          orderby o.date
                          group o by o.date.Year into sp
                          select new
                          {
                              _year = sp.Key.ToString(),
                              _outcome = sp.Sum(n => n.money)
                          };
            ViewBag.year = result.Select(n => n._year);
            ViewBag.outcome = result.Select(n => n._outcome);
            return PartialView();
        }
        public List<String> Mapdata(IEnumerable<string> labels)
        {
            Dictionary<int, string> label_map = MapTypeName.ReadLabelName();
            List<string> label_name = new List<string>();
            foreach(var label in labels)
            {
                label_name.Add(label_map[int.Parse(label)]);
            }
            return label_name;
        }
        public ActionResult OutcomeByType()
        {
            var outcome = Outcome.GetNoteOutcomes();
            var result = from o in outcome
                              orderby o.type
                              group o by o.type into p
                              select new
                              {
                                  _type = p.Key.ToString(),
                                  _outcome = p.Sum(n => n.money)
                              };
            
            ViewBag.type = Mapdata(result.Select(n => n._type));
            ViewBag.outcome = result.Select(n => n._outcome);
            return PartialView();
            }
    }
}