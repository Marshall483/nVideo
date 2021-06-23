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
        public CatalogRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Catalog_Entity> GetAllEntity()
        {
            return _context.Entities
                .Include(i => i.Images)
                .Include(a => a.Attributes)
                .ThenInclude(v => v.Value);
        }

        public List<Catalog_Attribute> GetAttributes(string category)
        {
            var attibutes = from a in _context.Entities 
                            where a.Category.CategoryName.Equals(category) 
                            select a.Attributes;
            
            return attibutes.First();
        }

        public IEnumerable<Catalog_Entity> GetCarouselItems()
        {
            return _context.Entities
                .Include(i => i.Images)
                .OrderByDescending(r => r.Raiting);
        }

        public IEnumerable<Catalog_Entity> GetCategoryMembers(string category)
        {
            return _context.Entities
                .Include(i => i.Images)
                .Include(e => e.Category)
                .Where(e => e.Category.CategoryName.Equals(category));
        }

        public IEnumerable<Catalog_Entity> GetFeaturedItems()
        {
            return _context.Entities
                .Include(i => i.Images)
                .OrderByDescending(r => r.Raiting);
        }

        public Catalog_Entity GetItemById(int? id)
        {
            if (!id.HasValue) 
                throw new ArgumentNullException("Missing parameter: int id");

            IQueryable<Catalog_Entity> target;

            return !(target = _context.Entities
                .Where(e => e.Id.Equals(id))).Any()
                ? throw new ArgumentException("Id is not exit")
                : target.Include(t => t.Images)
                    .Include(t => t.Category) //According to load related items.
                    .Include(t => t.Comments)
                    .ThenInclude(t => t.User)
                    .ThenInclude(u => u.Profile)
                    .Include(t => t.Attributes)
                    .ThenInclude(t => t.Value)
                    .Single(); //Must return only one. 
        }

        public IEnumerable<Catalog_Entity> GetNewItems()
        {
            return _context.Entities
                .Include(i => i.Images)
                .OrderByDescending(e => e.InStock)
                .Take(8);
        }

        public IEnumerable<Catalog_Entity> GetRandomItem()
        {
            return _context.Entities
                .Include(i => i.Images)
                .AsParallel()
                .Take(3);
        }

    }
}
