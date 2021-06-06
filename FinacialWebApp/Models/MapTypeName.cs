using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace FinacialWebApp.Models
{
    public class MapTypeName
    {
        public int typecode;
        public string typename;
        public static Dictionary<int, string> ReadLabelName()
        {
            Dictionary<int, string> label = new Dictionary<int, string>();
            string mapFile = @"D:\webprogramming\FinancialWebSite\Data\label_name.json";
            var json = File.ReadAllText(mapFile);
            JArray jArray = JArray.Parse(json);
            foreach(var item in jArray)
            {
                int typecode = int.Parse(item["code"].ToString());
                string label_name = item["name"].ToString();
                label.Add(typecode, label_name);
            }
            return label;
        }
    }
}