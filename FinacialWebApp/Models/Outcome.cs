using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FinacialWebApp.Models.DAO
{
    public class Outcome
    {
        DateTime date;
        public int type;
        string note;
        public double money;
        static string NoteOutcomesjsonFile = @"C:\Users\LAPTOP\source\repos\SavingMoney\SavingMoney\Data\NoteOutcomes.json";

        public Outcome(int t, DateTime d, string n, double m)
        {
            date = d;
            type = t;
            note = n;
            money = m;
        }
         private static List<Outcome> GetNoteOutcomes()
        {
            List<Outcome> noteOutcomes = new List<Outcome>();
            var json = File.ReadAllText(NoteOutcomesjsonFile);
            JArray jArray = JArray.Parse(json);
            foreach (var item in jArray)
            {
                string note = item["note"].ToString();
                var type = Int32.Parse(item["type"].ToString());
                var time = DateTime.Parse(item["time"].ToString());
                var money = Double.Parse(item["money"].ToString());
                noteOutcomes.Add(new Outcome(type, time, note, money));

            }
            return noteOutcomes;
        }
       static void AddNewOutCome(double money, DateTime time, int type, string note)
        {
            Outcome outcome = new Outcome(type, time, note, money);
            File.WriteAllText(NoteOutcomesjsonFile, JsonConvert.SerializeObject(outcome));
            
        }
        static IList GetOutcomesByYear()
        {
            var outcome = GetNoteOutcomes();
            var result = (from o in outcome
                     group o by o.date.Year into sp
                     select new
                     {
                         _month = sp.Key.ToString(),
                         _outcome = sp.Sum(n => n.money)
                     }).ToList();
            return result;
        }
        static IList GetOutcomesByMonth()
        {
            var outcome = GetNoteOutcomes();
            IList result = (from o in outcome
                         group o by o.date.Month into sp
                         select new
                         {
                             _month = sp.Key.ToString(),
                             _outcome = sp.Sum(n => n.money)
                         }).ToList();
            return result;
        }
    }
}