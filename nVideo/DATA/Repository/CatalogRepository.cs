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

        private readonly AppDBContext _context;

        public CatalogRepository(AppDBContext context) {
            _context = context;
        }

        public IEnumerable<Catalog_Entity> AllEntnty =>
            _context.Entities
            .Include(e => e.Images)
            .Include(e => e.Attributes)
            .ThenInclude(e => e.Value);
    }
}
