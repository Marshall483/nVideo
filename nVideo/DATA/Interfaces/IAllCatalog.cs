using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.DATA.Interfaces
{
    public interface IAllCatalog
    {
        public IEnumerable<Catalog_Entity> GetAllEntity();
        public IEnumerable<Catalog_Entity> GetCarouselItems();
        public IEnumerable<Catalog_Entity> GetFeaturedItems();
        public IEnumerable<Catalog_Entity> GetNewItems();
        public List<Catalog_Attribute> GetAttributes(string category);
        public IEnumerable<Catalog_Entity> GetRandomItem();
        public IEnumerable<Catalog_Entity> GetCategoryMembers(string category);
        public Catalog_Entity GetItemById(int? id);

    }
}
