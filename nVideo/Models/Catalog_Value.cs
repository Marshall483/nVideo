using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Models
{
    public class Catalog_Value
    {
        public int Id { get; set; }
        public int? IntegerValue { get; set; }
        public string StringValue { get; set; }
        public bool? BoolValue { get; set; }

        public int? Catalog_AttribiteId { get; set; }
        public Catalog_Attribute Attribute { get; set; }
    }
}
