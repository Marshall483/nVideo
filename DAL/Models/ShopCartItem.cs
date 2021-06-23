using System;

namespace Models
{
    public class ShopCartItem
    {
        public Guid Id { get; set; }
        public Catalog_Entity Entity { get; set; }
        public uint Quanity { get; set; }
        public string UserName { get; set; }

        public Catalog_Order Order { get; set; }
        public int? OrderId { get; set; }
    }
}
