using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinacialWebApp.Models.DAO;

namespace FinacialWebApp.Models
{
    public class OutcomeViewModel
    {
        public List<Outcome> outcomes { set; get; }
        public List<TypeModel> Types { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public string Money { get; set; }
    }
}