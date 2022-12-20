using ElectronicsStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Persistence
{
    public class EStoreSeeder
    {
        private readonly EStoreDbContext _dbContext;

        public EStoreSeeder(EStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Products.Any())
                {
                    var products = GetProducts();
                    _dbContext.Products.AddRange(products);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Categories.Any())
                {
                    var categories = GetCategories();
                    _dbContext.Categories.AddRange(categories);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Brands.Any())
                {
                    var brands = GetBrands();
                    _dbContext.Brands.AddRange(brands);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Brand> GetBrands()
        {
            return new List<Brand>()
            {
                new Brand()
                     {
                         Id = 1,
                         Name = "Apple",
                     },
                new Brand()
                {
                    Id = 2,
                    Name = "Samsung",
                },
                 new Brand()
                 {
                     Id = 3,
                     Name = "NoName",
                 }
            };
        }
        private IEnumerable<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category()
                     {
                         Id = 1,
                         Name = "Phones",
                     },
                new Category()
                {
                    Id = 2,
                    Name = "Devices",
                },
                 new Category()
                 {
                     Id = 3,
                     Name = "Accesories",
                 }
            };
        }
        private IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product()
               {
                   Id = 1,
                   Name = "iPhone 13 Pro Max",
                   IdCategory = 1,
                   Price = 109.99m,
                   IdBrand = 1,
               },
               new Product()
               {
                   Id = 2,
                   Name = "OnePlus 9",
                   IdCategory = 1,
                   Price = 89.99m,
                   IdBrand = 3
               },
               new Product()
               {
                   Id = 3,
                   Name = "Galaxy S21 FE",
                   IdCategory = 1,
                   Price = 99.99m,
                   IdBrand = 2
               },
               new Product()
               {
                   Id = 12,
                   Name = "iPhone 14 Pro Max",
                   IdCategory = 1,
                   Price = 129.99m,
                   IdBrand = 1
               },
               new Product()
               {
                   Id = 13,
                   Name = "iPhone 13",
                   IdCategory = 1,
                   Price = 99.99m,
                   IdBrand = 1
               },
               new Product()
               {
                   Id = 14,
                   Name = "iPhone 11",
                   IdCategory = 1,
                   Price = 69.99m,
                   IdBrand = 1
               },
                new Product()
                {
                Id = 15,
                   Name = "iPhone 12",
                   IdCategory = 1,
                   Price = 89.99m,
                   IdBrand = 1
               },
                new Product()
                {
                    Id = 16,
                    Name = "iPhone 12 Max",
                    IdCategory = 1,
                    Price = 95.99m,
                    IdBrand = 1
                },
               new Product()
               {
                   Id = 4,
                   Name = "iPad Pro 12,9",
                   IdCategory = 2,
                   Price = 119.99m,
                   IdBrand = 1
               },
               new Product()
               {
                   Id = 5,
                   Name = "Silver Monkey Kabel",
                   IdCategory = 3,
                   Price = 9.99m,
                   IdBrand = 3
               },
               new Product()
               {
                   Id = 6,
                   Name = "Microsoft 1850 Mouse",
                   IdCategory = 3,
                   Price = 29.99m,
                   IdBrand = 3
               },
               new Product()
               {
                   Id = 7,
                   Name = "NuPhy Air75 Red, Gateron",
                   IdCategory = 3,
                   Price = 9.99m,
                   IdBrand = 3
               },
               new Product()
               {
                   Id = 8,
                   Name = "Xiaomi Pad 5",
                   IdCategory = 2,
                   Price = 69.99m,
                   IdBrand = 3
               },
               new Product()
               {
                   Id = 9,
                   Name = "Galaxy Tab A8",
                   IdCategory = 2,
                   Price = 89.99m,
                   IdBrand = 2
               },
               new Product()
               {
                   Id = 10,
                   Name = "Huawei MatePad Paper",
                   IdCategory = 2,
                   Price = 89.99m,
                   IdBrand = 3
               },
               new Product()
               {
                   Id = 11,
                   Name = "ASUS RT-AC51",
                   IdCategory = 3,
                   Price = 29.99m,
                   IdBrand = 3
               }
            };
            return products;
        }
    }
}
