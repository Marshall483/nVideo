using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Models
{
    public class Ordered_Item
    {
        public int Id { get; set; }

        public Catalog_Entity Entity { get; set; }
        public uint Quanity { get; set; }

        public Catalog_Order Order { get; set; }
        public int? OrderId { get; set; }

        // ORM only
        protected Ordered_Item() { }

        public Ordered_Item(Catalog_Entity e, uint q)
        {
            Entity = e;
            Quanity = q;
        }

        public Ordered_Item(Catalog_Entity e, uint q, Catalog_Order o) : this(e, q)
        {
            Order = o;
        }
    }
}
