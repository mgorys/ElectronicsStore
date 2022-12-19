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
            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Name = "Apple iPhone 13 Pro Max Graphite",
                   IdCategory = 1,
                   Price = 109.99m
               },
               new Product
               {
                   Id = 2,
                   Name = "OnePlus 9 5G Astral Black 120Hz",
                   IdCategory = 1,
                   Price = 89.99m
               },
               new Product
               {
                   Id = 3,
                   Name = "Samsung Galaxy S21 FE 5G Fan Edition Grey",
                   IdCategory = 1,
                   Price = 99.99m
               },
               new Product
               {
                   Id = 4,
                   Name = "Apple iPad Pro 12,9\" M1 Wi - Fi Space Gray",
                   IdCategory = 2,
                   Price = 119.99m
               },
               new Product
               {
                   Id = 5,
                   Name = "Silver Monkey Kabel USB 3.0 - USB-C 1,2m",
                   IdCategory = 3,
                   Price = 9.99m
               },
               new Product
               {
                   Id = 6,
                   Name = "Microsoft 1850 Wireless Mobile Mouse",
                   IdCategory = 3,
                   Price = 29.99m
               },
               new Product
               {
                   Id = 7,
                   Name = "NuPhy Air75 Red, Gateron",
                   IdCategory = 3,
                   Price = 9.99m
               },
               new Product
               {
                   Id = 8,
                   Name = "Xiaomi Pad 5 6/128GB Cosmic Gray 120Hz",
                   IdCategory = 2,
                   Price = 69.99m
               },
               new Product
               {
                   Id = 9,
                   Name = "Samsung Galaxy Tab A8 X200 WiFi 4/64GB srebrny",
                   IdCategory = 2,
                   Price = 89.99m
               },
               new Product
               {
                   Id = 10,
                   Name = "Huawei MatePad Paper 4/64GB WiFi ",
                   IdCategory = 2,
                   Price = 89.99m
               },
               new Product
               {
                   Id = 11,
                   Name = "ASUS RT-AC51 (750Mb/s a/b/g/n/ac)",
                   IdCategory = 3,
                   Price = 29.99m
               }
                        );
        }

    }
}
