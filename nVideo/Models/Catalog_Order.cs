#nullable enable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace nVideo.Models
{
    public class Catalog_Order
    {
        public int Id { get; set; }
        
        public DateTime CreatedTime { get; set; }    
        
        public string? UserId { get; set; }
        public User? User { get; set; } // null in case anonymous user

        public int CustomerDataId { get; set; }
        public UserProfile CustomerData { get; set; } // Del address, phone and etc.

        public string State { get; set; } // Open, InProcess, Closed

        public IEnumerable<ShopCartItem> Items { get; set; }
    }
}