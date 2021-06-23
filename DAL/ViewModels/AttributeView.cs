using System.Collections.Generic;

namespace Models
{
    public class AttributeView
    {
        public string Name { get; set; }
        public List<Catalog_Value> Values { get; set; }
        public Dictionary<string, string> Dict { get; set; }

        public AttributeView(string name, List<Catalog_Value> values, Dictionary<string, string> dict)
        {
            Name = name;
            Values = values;
            Dict = dict;
        }

    }
}
