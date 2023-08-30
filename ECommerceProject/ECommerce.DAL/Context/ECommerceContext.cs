using ECommerce.Entity.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Context
{
    public class ECommerceContext:IdentityDbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext>options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }




      

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(

                new Category {Id=1,CategoryName="Giyim",Description="Yazlık" },
                new Category { Id=2,CategoryName="Teknoloji",Description="Bilgisayar"});
            base.OnModelCreating(builder);
        }
        }
    }

