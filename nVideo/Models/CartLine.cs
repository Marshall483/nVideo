using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Models
{
    public class CartLine
    {
        public Catalog_Entity Entity { get; set; }
        public int Quantity { get; set; }
    }
}
