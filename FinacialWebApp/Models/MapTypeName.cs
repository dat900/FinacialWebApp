using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FinacialWebApp.Models
{
    public class MapTypeName
    {
        public Dictionary<int, string> ReadLabelName()
        {
            Dictionary<int, string> label = new Dictionary<int, string>();
            string mapFile = @"C:\Users\LAPTOP\source\repos\FinacialWebApp\FinacialWebApp\Data\label_name.json";
            var json = File.ReadAllText(mapFile);
            while(json.Count() > 0)
            {
                //int typecode = int.Parse(json.sel)
            }
            return label;
        }
    }
}