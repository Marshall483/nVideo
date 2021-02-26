using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.DATA.ViewModels
{
    public class CatalogViewModel
    {
        public IEnumerable<Catalog_Entity> Entities { get; set; }

    }
}
