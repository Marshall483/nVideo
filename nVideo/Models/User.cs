using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Models
{
    public class User : IdentityUser
    {

        public List<Comment> Comments  { get; set; }

        public int? ProfileId { get; set; }
        public UserProfile Profile { get; set; }
    }
}
