using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Attribute> Attributes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Value> Values { get; set; }
    }
}
