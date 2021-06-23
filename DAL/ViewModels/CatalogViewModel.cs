using Models;
using System.Collections.Generic;

namespace ViewModels
{
    public class CatalogViewModel
    {
        public IEnumerable<Catalog_Entity> Entities { get; set; }
        public Dictionary<string, string> Dict { get; set; }
    }
}
