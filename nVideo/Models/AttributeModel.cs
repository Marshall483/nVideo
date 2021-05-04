using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Models
{
    public class AttributeModel
    {
        public AttributeModel(string name, int? intValue)
        {
            Name = name;
            IntValue = intValue;
        }
        public AttributeModel(string name, string? stringValue)
        {
            Name = name;
            StringValue = stringValue;
        }
        public AttributeModel(string name, List<Catalog_Value> values)
        {
            Name = name;
            Values = values;
        }
        public string Name { get; set; }
        public int? IntValue { get; set; }
        public string? StringValue { get; set; }
        public List<Catalog_Value> Values { get; set; }
    }
}
