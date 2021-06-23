using System.Collections.Generic;

namespace Models
{
    public class FilterModel
    {
        public Dictionary<string, List<Catalog_Value>> Attributes { get; set; }
        public Dictionary<string, string> DefaultValue { get; set; }
    }
}
