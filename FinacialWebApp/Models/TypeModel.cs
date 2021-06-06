using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinacialWebApp.Models
{
    public class TypeModel
    {
        public int Type_num { get; set; }
        public string Type_name { get; set; }
        public static List<TypeModel> GetTypeModel()
        {
            List<TypeModel> types = new List<TypeModel>();
            Dictionary<int, string> label_map = MapTypeName.ReadLabelName();            
            foreach (var label in label_map)
            {
                TypeModel type = new TypeModel();
                type.Type_num = label.Key;
                type.Type_name = label.Value;
                types.Add(type);
            }
            return types;
        }
    }
}