using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace nVideo.Models
{
    public class User : IdentityUser
    {
        public List<Comment> Comments  { get; set; }
        public int? ProfileId { get; set; }
        public UserProfile Profile { get; set; }
        public IEnumerable<Catalog_Order> Orders { get; set; }
       // public State<Cart> Cart { get; set; }
    }
}
