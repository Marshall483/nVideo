using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using nVideo.Models;

namespace nVideo.DATA
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

        }

        public DbSet<Catalog_Category> Categories { get; set; }
        public DbSet<Catalog_Entity> Entities { get; set; }
        public DbSet<Catalog_Attribute> Attributes { get; set; }
        public DbSet<Catalog_Value> Values { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Catalog_Order> Orders { get; set; }
    }
}
