using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Models
{
    public class Catalog_Attribute
    {
        public int Id { get; set; }
        public string AttributeName { get; set; }

        public int? EntityId { get; set; }
        public Catalog_Entity Entity { get; set; }

        public Catalog_Value Value { get; set; }
    }
}
