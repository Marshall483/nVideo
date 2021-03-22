using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.DATA.Interfaces
{
    public interface IAllCatalog
    {
        public IEnumerable<Catalog_Entity> GetAllEntnty { get; }
        public IEnumerable<Catalog_Entity> GetCarouselItems { get; }
        public IEnumerable<Catalog_Entity> GetFeaturedItems { get; }
        public IEnumerable<Catalog_Entity> GetNewItems { get; }
        public Catalog_Entity GetRandomItem { get; }

        public IEnumerable<Catalog_Entity> GetCategoryMembers(string category);
        public Catalog_Entity GetItemById(int? id);

    }
}
