using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Models
{
    public class Catalog_Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual List<Catalog_Entity> Entities { get; set; }
    }
}
