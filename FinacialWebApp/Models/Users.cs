using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json.Linq;

namespace FinacialWebApp.Models
{
    public class Users
    {
        public string username { get; set; }
        public string password { get; set; }
        public static Users ReadData()
        {
            string file = @"D:\webprogramming\FinancialWebSite\Data\logindata.json";
            var json = File.ReadAllText(file);
            JArray jArray = JArray.Parse(json);
            Users login = new Users();
            login.username = jArray[0]["username"].ToString();
            login.password = jArray[0]["password"].ToString();
            return login;
        }
    }
    
}