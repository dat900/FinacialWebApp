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
        private string note;

        public double Money { get => money; set => money = value; }
        public int Month { get => month; set => month = value; }
        public int Year { get => year; set => year = value; }
        public string Note { get => note; set => note = value; }

        static string BankjsonFile = @"C:\Users\LAPTOP\source\repos\FinacialWebApp\FinacialWebApp\Data\Income.json";


        public Income(int month, int year, double inc, string note)
        {
            Month = month;
            Year = year;
            Money = inc;
            Note = note;
        }
        public static List<Income> GetIncome()
        {
            List<Income> bank = new List<Income>();
            var json = File.ReadAllText(BankjsonFile);
            JArray jArray = JArray.Parse(json);
            foreach (var item in jArray)
            {
                var year = int.Parse(item["Year"].ToString());
                var month = int.Parse(item["Month"].ToString());
                var money = double.Parse(item["Money"].ToString());
                var note = item["Note"].ToString();
                bank.Add(new Income(month, year, money, note));
            }
            return bank;
        }
        public static void AddNewIncome(DateTime date, double money, string note)
        {
            Income income = new Income(date.Month, date.Year, money*1000, note);
            List<Income> incomes = GetIncome();
            incomes.Add(income);
            File.WriteAllText(BankjsonFile, JsonConvert.SerializeObject(incomes));
        }
    }
}