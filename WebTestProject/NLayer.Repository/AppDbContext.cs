using Microsoft.EntityFrameworkCore;

using System.Reflection;
using NLayer.Core.Entity;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Colour = "Kırmızı",
                Height = 100,
                Widht = 200,
                ProductId = 1,
            },
            new ProductFeature()
            {
                Id = 2,
                Colour = "Mavi",
                Height = 100,
                Widht = 200,
                ProductId = 2,
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
