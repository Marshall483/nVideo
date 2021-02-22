using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Models
{
    public class Image
    {

        public int Id { get; set; }
        public string Patch { get; set; }


        public int? Catalog_EntityId { get; set; }
        public Catalog_Entity Entity { get; set; }

    }
}
