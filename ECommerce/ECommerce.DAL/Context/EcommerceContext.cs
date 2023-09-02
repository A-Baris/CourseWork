using ECommerce.Entity.Base;
using ECommerce.Entity.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ECommerce.DAL.Context
{
    public class EcommerceContext : IdentityDbContext
    {
     



        //Dbset
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-KUQ9PNH;database=ECommerceDB;uid=sa;pwd=1234;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        
            base.OnModelCreating(builder);
        }


      

        public override int SaveChanges()
        {

            //veri yeni eklenirken

            //veri güncellenirken 

            var modifierEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added);

            try
            {
                foreach (var item in modifierEntries)
                {
                    var entityRepository = item.Entity as BaseClass;
                    if (item.State == EntityState.Modified)
                    {
                        entityRepository.UpdatedDate = DateTime.Now;
                        entityRepository.UpdatedIpAddress = "111111";
                        entityRepository.UpdatedComputerName = Environment.MachineName;

                    }
                    else if (item.State == EntityState.Added)
                    {
                        entityRepository.CreatedDate = DateTime.Now;
                        entityRepository.CreatedIpAddress = "222222";
                        entityRepository.CreatedComputerName=Environment.MachineName;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


            return base.SaveChanges();
        }
    }
}
