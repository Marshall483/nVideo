using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Models
{
    public class AttributeView
    {
        public AttributeView(string name, List<Catalog_Value> values)
        {
            Name = name;
            Values = values;
        }

        public string Name { get; set; }
        public List<Catalog_Value> Values { get; set; }
    }
}
