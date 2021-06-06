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
        private decimal money;
        private int month;
        private int year;
        private string note;

        public decimal Money { get => money; set => money = value; }
        public int Month { get => month; set => month = value; }
        public int Year { get => year; set => year = value; }
        public string Note { get => note; set => note = value; }

        const string BanksFile = @"D:\webprogramming\FinancialWebSite\Data\Income.json";
      
        public static List<Income> GetIncome()
        {
            List<Income> bank = new List<Income>();
            var json = File.ReadAllText(BanksFile);
            JArray jArray = JArray.Parse(json);
            foreach (var item in jArray)
            {
                Income income = new Income();
                income.month = int.Parse(item["Month"].ToString());
                income.year = int.Parse(item["Year"].ToString());
                income.money = decimal.Parse(item["Money"].ToString());
                income.note = item["Note"].ToString();
                bank.Add(income);
            }
            return bank;
        }
        public static void AddNewIncome(DateTime date, decimal money, string note)
        {
            Income income = new Income();
            income.month = date.Month;
            income.year = date.Year;
            income.money = money * 1000;
            income.note = note;
            List<Income> incomes = GetIncome();
            incomes.Add(income);
            File.WriteAllText(BanksFile, JsonConvert.SerializeObject(incomes));
        }
        public static void UpdateIncome(List<Income> incomes)
        {
            File.WriteAllText(BanksFile, JsonConvert.SerializeObject(incomes));
        }
        public static List<Income> AddNewLine(List<Income> incomes)
        {
            Income income = new Income();
            income.year = DateTime.Now.Year;
            income.month = DateTime.Now.Month;
            incomes.Add(income);
            return incomes;
        }
    }
}