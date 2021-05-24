using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Models
{
    public class FilterModel
    {
        public Dictionary<string, List<Catalog_Value>> Attributes { get; set; }
        public Dictionary<string, string> DefaultValue { get; set; }
    }
}
