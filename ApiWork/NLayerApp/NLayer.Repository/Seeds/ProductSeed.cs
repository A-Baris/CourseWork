﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                CategoryId = 1,
                Name = "Kalem1",
                Price = 100,
                Stock = 20,
                CreatedDate = DateTime.Now,

            },
            new Product
            {
                Id = 2,
                CategoryId = 2,
                Name = "Kitap1",
                Price = 300,
                Stock = 10,
                CreatedDate = DateTime.Now,
            });
            
            
        }
    }
}
