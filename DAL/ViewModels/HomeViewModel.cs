using System.Collections.Generic;
using Models;

namespace ViewModels
{
    public class HomeViewModel
    {
        // 3 items wich spec picture
        public IEnumerable<Catalog_Entity> ForCarousel { get; set; }
        //8 items
        public IEnumerable<Catalog_Entity> ForNewProductsBlock { get; set; }
        //3 items
        public IEnumerable<Catalog_Entity> ForThumbnailBlock { get; set; }
        //3 items by raiting
        public IEnumerable<Catalog_Entity> ForFeaturedBlock { get; set; }
    }
}
