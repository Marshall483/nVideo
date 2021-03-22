using Microsoft.EntityFrameworkCore;
using nVideo.DATA.Interfaces;
using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.DATA.Repository
{
    public class CatalogRepository : IAllCatalog
    {
        private readonly AppDbContext _context;

        private static IQueryable<Catalog_Entity> _entities;
        public IQueryable<Catalog_Entity> Entities {
            get {
                return _context.Entities
                               .Include(e => e.Images);
            }
        }

        public CatalogRepository(AppDbContext context) {
            _context = context;
        }

        public IEnumerable<Catalog_Entity> GetCarouselItems {
            get {
                return GetFeaturedItems;
            }
        }

        public IEnumerable<Catalog_Entity> GetFeaturedItems{
            get{
                return Entities.OrderByDescending(e => e.Raiting)
                    .Take(3);
            }
        }

        public IEnumerable<Catalog_Entity> GetNewItems{
            get{
                return Entities.OrderByDescending(e => e.InStock)
                    .Take(8);
            }
        }

        public Catalog_Entity GetRandomItem{
            get{
                var rnd = new Random(DateTime.Now.Millisecond);
                return Entities.ToArray()[rnd.Next(0, Entities.Count())];
            }
        }

        public IEnumerable<Catalog_Entity> GetCategoryMembers(string  category) {
            return Entities.Include(e => e.Category)
                .Where(e => e.Category.CategoryName.Equals(category));
        }

        public Catalog_Entity GetItemById(int? id){
            if (id.HasValue){
                IQueryable<Catalog_Entity> target;

                return (target = Entities.Where(e => e.Id.Equals(id)))
                                         .Count() == 0
                                              ? throw new ArgumentException("Id is not exit")
                                              : target.Include(t => t.Attributes)
                                                      .ThenInclude(t => t.Value)
                                                      .First();
            }
            throw new ArgumentNullException("Missing parameter: int id");
        }


        public IEnumerable<Catalog_Entity> GetAllEntnty =>
             Entities.Include(e => e.Attributes)
                     .ThenInclude(e => e.Value);
    }
}
