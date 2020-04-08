using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FinacialWebApp.Models.DAO
{
    public class Income
    {
        private double money;
        private int month;
        private int year;
        private double living_fee;
        private  double freedom;
        private double donation;
        private double education;
        private double saving;
        private double play;

        public double Money { get => money; set => money = value; }
        public int Month { get => month; set => month = value; }
        public int Year { get => year; set => year = value; }
        public double Living_fee { get => living_fee; set => living_fee = value; }
        public double Freedom { get => freedom; set => freedom = value; }
        public double Donation { get => donation; set => donation = value; }
        public double Education { get => education; set => education = value; }
        public double Saving { get => saving; set => saving = value; }
        public double Play { get => play; set => play = value; }
        static string BankjsonFile = @"C:\Users\LAPTOP\source\repos\FinacialWebApp\FinacialWebApp\Data\Income.json";


        public Income(DateTime t, double inc)
        {
            Month = t.Month;
            Year = t.Year;
            Money = inc;
            Living_fee = inc * 0.55;
            Freedom = inc * 0.1;
            Donation = inc * 0.15;
            Education = inc * 0.1;
            Saving = inc * 0.1;
            Play = inc * 0.1;
        }
        static List<Income> GetIncome()
        {
            List<Income> bank = new List<Income>();
            var json = File.ReadAllText(BankjsonFile);
            JArray jArray = JArray.Parse(json);
            foreach (var item in jArray)
            {
                var dateTime = DateTime.Parse(item["time"].ToString());
                var money = Double.Parse(item["income"].ToString());
                bank.Add(new Income(dateTime, money));
            }
            return bank;
        }
        public static (Array, Array) GetIncomeByMonth()
        {
            var income = GetIncome();
            var result = from i in income
                         orderby i.Month
                         group i by i.Month into sp
                         
                         select new 
                         {
                             month = sp.Key.ToString(),
                             money = sp.Sum(n => n.Money)
                         };
            
            return (result.Select(n => n.month).ToArray(), result.Select(n => n.money).ToArray());
        }
        static Object GetIncomeByYear()
        {
            var income = GetIncome();
            var result = from i in income
                         group i by i.Year into sp
                         select new
                         {
                             _year = sp.Key.ToString(),
                             _money = sp.Sum(n => n.Money)
                         };
            return result;
        }
        public void AddNewIncome(DateTime date, double money)
        {
            Income income = new Income(date, money*1000);
            File.WriteAllText(BankjsonFile, JsonConvert.SerializeObject(income));
        }
    }
}