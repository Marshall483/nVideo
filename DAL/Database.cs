using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class Database : IdentityDbContext<User>
    {
        public DbSet<Catalog_Category> Categories { get; set; }
        public DbSet<Catalog_Entity> Entities { get; set; }
        public DbSet<Catalog_Attribute> Attributes { get; set; }
        public DbSet<Catalog_Value> Values { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Catalog_Order> Orders { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Ordered_Item> OrderedItem { get; set; }


        public Database(DbContextOptions<Database> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Catalog_Entity>()
                .HasGeneratedTsVectorColumn(
                    p => p.SearchVector,
                    "english",
                    p => new { p.Name, p.Long_Desc })
                .HasIndex(p => p.SearchVector)
                .HasMethod("GIN");
        }
    }
}
