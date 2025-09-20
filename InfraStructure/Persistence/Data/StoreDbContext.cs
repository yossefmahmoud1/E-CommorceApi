﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.Producr;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Presention.Data
{
     public class StoreDbContext : DbContext
    {

      

             public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {



        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyRefrence).Assembly);
        }

    }

    
}
