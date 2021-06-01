using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable

namespace nVideo.Models
{
    public class AttributeView
    {
        public AttributeView(string name, List<Catalog_Value> values, Dictionary<string, string> dict)
        {
            Name = name;
            Values = values;
            Dict = dict;
        }

        public string Name { get; set; }
        public List<Catalog_Value> Values { get; set; }
        public Dictionary<string, string> Dict { get; set; }
    }
}
