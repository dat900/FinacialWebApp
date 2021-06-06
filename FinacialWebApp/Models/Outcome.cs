using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using FinacialWebApp.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FinacialWebApp.Models.DAO
{
    public class Outcome
    {
        private DateTime date;
        private int type;
        private double money;
        private string note;


        const string NoteOutcomesjsonFile = @"D:\webprogramming\FinancialWebSite\Data\NoteOutcomes.json";

        public DateTime Date { get => date; set => date = value; }
        public int Type { get => type; set => type = value; }
        public double Money { get => money; set => money = value; }
        public string Note { get => note; set => note = value; }

        public static List<Outcome> GetNoteOutcomes()
        {
            List<Outcome> noteOutcomes = new List<Outcome>();
            var json = File.ReadAllText(NoteOutcomesjsonFile);
            JArray jArray = JArray.Parse(json);
            foreach (var item in jArray)
            {
                Outcome outcome = new Outcome();
                outcome.Note = item["Note"].ToString();
                outcome.Type = int.Parse(item["Type"].ToString());
                outcome.Date = DateTime.Parse(item["Date"].ToString());
                outcome.Money = double.Parse(item["Money"].ToString());
                noteOutcomes.Add(outcome);

            }
            return noteOutcomes;
        }
        public static void AddNewOutCome(double money, DateTime time, int type, string note)
        {
            Outcome outcome = new Outcome();
            outcome.Type = type;
            if (CalculationIndex.TYPE_INSURANCE == type)
            {
                outcome.Date = new DateTime(time.Year, CalculationIndex.LAST_MONTH, CalculationIndex.LAST_DATE);
                outcome.Note = note + "( " + outcome.date.ToString("dd/MM/yyyy") + " )";
            }
            else
            {
                outcome.Date = time;
                outcome.Note = note;
            }

            outcome.Money = money * 1000;
            List<Outcome> outcomes = GetNoteOutcomes();
            outcomes.Add(outcome);
            File.WriteAllText(NoteOutcomesjsonFile, JsonConvert.SerializeObject(outcomes));
        }
        public static void UpdateOutcomes(List<Outcome> outcomes)
        {
            File.WriteAllText(NoteOutcomesjsonFile, JsonConvert.SerializeObject(outcomes));
        }
        public static List<Outcome> AddNewLine(List<Outcome> outcomes)
        {
            Outcome outcome = new Outcome();
            outcome.date = DateTime.Now;
            outcomes.Add(outcome);
            return outcomes;
        }

    }
}