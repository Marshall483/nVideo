#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace nVideo.Models
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
        
        public string? UserId { get; set; }
        public User? User { get; set; } 
        public int? CustomerDataId { get; set; }
        public UserProfile CustomerData { get; set; } 

        public string State { get; set; } 

        public bool IsSelfDelivery { get; set; }
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public City? PickUpFrom { get; set; }

        public IEnumerable<Ordered_Item> OrderedItems { get; set; }
    }
}