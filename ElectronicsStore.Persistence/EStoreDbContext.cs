using ElectronicsStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Persistence
{
    public class EStoreDbContext : DbContext
    {
        public EStoreDbContext(DbContextOptions<EStoreDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                     new Category
                     {
                         Id = 1,
                         Name = "Phones",
                     },
                new Category
                {
                    Id = 2,
                    Name = "Devices",
                },
                 new Category
                 {
                     Id = 3,
                     Name = "Accesories",
                 }
                ); 
            modelBuilder.Entity<Brand>().HasData(
                     new Category
                     {
                         Id = 1,
                         Name = "Apple",
                     },
                new Category
                {
                    Id = 2,
                    Name = "Samsung",
                },
                 new Category
                 {
                     Id = 3,
                     Name = "NoName",
                 }
                );
            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Name = "iPhone 13 Pro Max",
                   IdCategory = 1,
                   Price = 109.99m,
                   IdBrand = 1,
               },
               new Product
               {
                   Id = 2,
                   Name = "OnePlus 9",
                   IdCategory = 1,
                   Price = 89.99m,
                   IdBrand = 3
               },
               new Product
               {
                   Id = 3,
                   Name = "Galaxy S21 FE",
                   IdCategory = 1,
                   Price = 99.99m,
                   IdBrand = 2
               },
               new Product
               {
                   Id = 4,
                   Name = "iPad Pro 12,9",
                   IdCategory = 2,
                   Price = 119.99m,
                   IdBrand = 1
               },
               new Product
               {
                   Id = 5,
                   Name = "Silver Monkey Kabel",
                   IdCategory = 3,
                   Price = 9.99m,
                   IdBrand = 3
               },
               new Product
               {
                   Id = 6,
                   Name = "Microsoft 1850 Mouse",
                   IdCategory = 3,
                   Price = 29.99m,
                   IdBrand = 3
               },
               new Product
               {
                   Id = 7,
                   Name = "NuPhy Air75 Red, Gateron",
                   IdCategory = 3,
                   Price = 9.99m,
                   IdBrand = 3
               },
               new Product
               {
                   Id = 8,
                   Name = "Xiaomi Pad 5",
                   IdCategory = 2,
                   Price = 69.99m,
                   IdBrand = 3
               },
               new Product
               {
                   Id = 9,
                   Name = "Galaxy Tab A8",
                   IdCategory = 2,
                   Price = 89.99m,
                   IdBrand = 2
               },
               new Product
               {
                   Id = 10,
                   Name = "Huawei MatePad Paper",
                   IdCategory = 2,
                   Price = 89.99m,
                   IdBrand = 3
               },
               new Product
               {
                   Id = 11,
                   Name = "ASUS RT-AC51",
                   IdCategory = 3,
                   Price = 29.99m,
                   IdBrand = 3
               }
            );
        }

    }
}
