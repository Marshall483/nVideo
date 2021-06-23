using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace ViewModels
{
    public class ShopCartView
    {
        public IEnumerable<ShopCartItem> ShopCartItems { get; private set; }
        public long TotalValue { get; private set; }
        public SelectList DeliveryType { get; set; }

        public ShopCartView(IEnumerable<ShopCartItem> shopCartItems,
            long totalValue, SelectList deliveryType)
        {
            ShopCartItems = shopCartItems;
            TotalValue = totalValue;
            DeliveryType = deliveryType;
        }
        
        
    }
}
