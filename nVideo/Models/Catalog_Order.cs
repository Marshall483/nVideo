using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace nVideo.Models
{
    public class Catalog_Order
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }

        public DateTime Oreder_Time { get; set; }    
        
        public User User { get; set; }
        
        public List<Catalog_Entity> Items { get; set; }
    }
}