using System;


namespace nVideo.Models
{
    public class ShopCartItem
    {
        public Guid Id { get; set; }
        public Catalog_Entity Entity { get; set; }
        public uint Quanity { get; set; }
        public string ShopCartId { get; set; }
    }



}
