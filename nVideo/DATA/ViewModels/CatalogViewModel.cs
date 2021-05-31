using nVideo.Models;
using System.Collections.Generic;

namespace nVideo.DATA.ViewModels
{
    public class CatalogViewModel
    {
        public IEnumerable<Catalog_Entity> Entities { get; set; }
        public Dictionary<string, string> Dict { get; set; }
    }
}
