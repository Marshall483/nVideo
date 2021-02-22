using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? EntityId { get; set; }
        public Catalog_Entity Entity { get; set; }
    }
}
