using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.DATA
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options){

        }

        public List<Catalog_Category> Categories { get; set; }
        public List<Catalog_Entity> Entities { get; set; }
        public List<Catalog_Attribute> Attributes { get; set; }
        public List<Catalog_Value> Values { get; set; }
        public List<Image> Images { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
