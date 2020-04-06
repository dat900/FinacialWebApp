using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json.Linq;

namespace FinacialWebApp.Models.DAO
{
    public class Income
    {
        public double income;
        private int month;
        private int year;
        private double living_fee;
        private  double freedom;
        private double donation;
        private double education;
        private double saving;
        private double play;
        public Income(DateTime t, double inc)
        {
            month = t.Month;
            year = t.Year;
            income = inc;
            living_fee = inc * 0.55;
            freedom = inc * 0.1;
            donation = inc * 0.15;
            education = inc * 0.1;
            saving = inc * 0.1;
            play = inc * 0.1;
        }
        static List<Income> GetIncome()
        {
            string BankjsonFile = @"C:\Users\LAPTOP\source\repos\FinacialWebApp\FinacialWebApp\Data\Income.json";
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
                         orderby i.month
                         group i by i.month into sp
                         
                         select new 
                         {
                             month = sp.Key.ToString(),
                             money = sp.Sum(n => n.income)
                         };
            
            return (result.Select(n => n.month).ToArray(), result.Select(n => n.money).ToArray());
        }
        static Object GetIncomeByYear()
        {
            var income = GetIncome();
            var result = from i in income
                         group i by i.year into sp
                         select new
                         {
                             _year = sp.Key.ToString(),
                             _money = sp.Sum(n => n.income)
                         };
            return result;
        }
    }
}