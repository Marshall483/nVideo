using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Models
{
    public enum OrderState : byte
    {
        Open,
        ReadyToPick,
        InProgress,
        Closed
    }

    public class Catalog_Order
    {
        public int Id { get; set; }
        
        public DateTime CreatedTime { get; set; }    
        
        public string UserId { get; set; }
        public User User { get; set; } 

        public int? CustomerDataId { get; set; }
        public UserProfile CustomerData { get; set; } 

        public string State { get; set; } 

        public bool IsSelfDelivery { get; set; }
        
        public Guid? CityId { get; set; }
        [ForeignKey("CityId")]
        public City PickUpFrom { get; set; }

        public IEnumerable<Ordered_Item> OrderedItems { get; set; }
    }

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