using System.Collections.Generic;


namespace nVideo.Models
{
    public class ShopCartView
    {
        public IEnumerable<ShopCartItem> ShopCartItems { get; private set; }
        public long TotalValue { get; private set; }

        public ShopCartView(IEnumerable<ShopCartItem> shopCartItems, long totalValue)
        {
            ShopCartItems = shopCartItems;
            TotalValue = totalValue;
        }

    }
}
