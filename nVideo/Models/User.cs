using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace nVideo.Models
{
    public class User : IdentityUser
    {
        public List<Comment> Comments  { get; set; }
        public int? ProfileId { get; set; }
        public UserProfile Profile { get; set; }
        public IEnumerable<Catalog_Order> Orders { get; set; }
    }
}
