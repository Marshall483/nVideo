using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IAllCatalog
    {
        IEnumerable<Catalog_Entity> GetAllEntity();
        IEnumerable<Catalog_Entity> GetCarouselItems();
        IEnumerable<Catalog_Entity> GetFeaturedItems();
        IEnumerable<Catalog_Entity> GetNewItems();
        List<Catalog_Attribute> GetAttributes(string category);
        IEnumerable<Catalog_Entity> GetRandomItem();
        IEnumerable<Catalog_Entity> GetCategoryMembers(string category);
        Catalog_Entity GetItemById(int? id);
    }
}
