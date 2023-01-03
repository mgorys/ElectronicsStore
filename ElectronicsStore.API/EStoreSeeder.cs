using ElectronicsStore.Abstractions.IRepositories;
using ElectronicsStore.Abstractions.IServices;
using ElectronicsStore.Entities;
using ElectronicsStore.Models.Dto;
using ElectronicsStore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.API
{
    public class EStoreSeeder
    {
        private readonly EStoreDbContext _dbContext;
        private readonly IAccountRepository _accountRepository;

        public EStoreSeeder(EStoreDbContext dbContext, IAccountRepository accountRepository)
        {
            _dbContext = dbContext;
            _accountRepository = accountRepository;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (_dbContext.Users.FirstOrDefault(x=>x.Role == "Admin") == null)
                {
                    var admin = new RegisterDto()
                    {
                        Email = "admin@admin.com",
                        Password = "admin",
                        ConfirmPassword = "admin",
                        Role = "Admin",
                        Name = "Admin"
                    };
                    _accountRepository.RegisterAdmin(admin);
                }

                //if (!_dbContext.Products.Any())
                //{
                //    var products = GetProducts();
                //    _dbContext.Products.AddRange(products);
                //    _dbContext.SaveChanges();
                //}
                //if (!_dbContext.Categories.Any())
                //{
                //    var categories = GetCategories();
                //    _dbContext.Categories.AddRange(categories);
                //    _dbContext.SaveChanges();
                //}
                //if (!_dbContext.Brands.Any())
                //{
                //    var brands = GetBrands();
                //    _dbContext.Brands.AddRange(brands);
                //    _dbContext.SaveChanges();
                //}
            }
        }
        //private IEnumerable<Brand> GetBrands()
        //{
        //    return new List<Brand>()
        //    {
        //        new Brand()
        //             {
        //                 Id = 1,
        //                 Name = "Apple",
        //             },
        //        new Brand()
        //        {
        //            Id = 2,
        //            Name = "Samsung",
        //        },
        //         new Brand()
        //         {
        //             Id = 3,
        //             Name = "NoName",
        //         }
        //    };
        //}
        //private IEnumerable<Category> GetCategories()
        //{
        //    return new List<Category>()
        //    {
        //        new Category()
        //             {
        //                 Id = 1,
        //                 Name = "Phones",
        //             },
        //        new Category()
        //        {
        //            Id = 2,
        //            Name = "Devices",
        //        },
        //         new Category()
        //         {
        //             Id = 3,
        //             Name = "Accessories",
        //         }
        //    };
        //}
        //private IEnumerable<Product> GetProducts()
        //{
        //    var products = new List<Product>()
        //    {
        //          new Product
        //       {
        //           Id = 1,
        //           Name = "iPhone 13 Pro Max",
        //           IdCategory = 1,
        //           Price = 109.99m,
        //           IdBrand = 1,
        //           ImgUrl = "https://media.4rgos.it/s/Argos/9520103_R_SET?$Main768$&w=620&h=620",
        //           Description = "The iPhone 13 Pro Max is Apple's biggest phone in the lineup with a massive, 6.7\" screen that for the first time in an iPhone comes with 120Hz ProMotion display that ensures super smooth scrolling. The benefit of such a gigantic phone is that it also comes with the biggest battery of all iPhone 13 series."
        //       },
        //       new Product
        //       {
        //           Id = 2,
        //           Name = "OnePlus 9",
        //           IdCategory = 1,
        //           Price = 89.99m,
        //           IdBrand = 3,
        //           ImgUrl = "https://auspost.com.au/shop/static/WFS/AusPost-Shop-Site/-/AusPost-Shop-auspost-B2CWebShop/en_AU/feat-cat/mobile-phones/always-on/category-tiles/MP_UnlockedPhones_3.jpg",
        //           Description = "The OnePlus 9 5G and 9 Pro 5G are Android-based smartphones manufactured by OnePlus, unveiled on March 23, 2021. The phones feature upgraded cameras developed in partnership with Hasselblad."

        //       },
        //       new Product
        //       {
        //           Id = 3,
        //           Name = "Galaxy S21 FE",
        //           IdCategory = 1,
        //           Price = 99.99m,
        //           IdBrand = 2,
        //           ImgUrl = "https://www.optus.com.au/content/dam/optus/images/shop/prepaid/phones/optus/optus-x-pro-2/product-tile/OptusXPro2-front-listings.png/renditions/version-1652263444394/original.png",
        //           Description = "The Samsung Galaxy S21 FE is a budget-friendly smartphone released in 2021 that features a 6.5-inch Super AMOLED display, triple camera system, Qualcomm Snapdragon 888 processor, 5G connectivity, long-lasting battery, and Android 11 operating system. It offers many of the same features and capabilities as the more expensive Galaxy S21 models at a more affordable price."
        //       },
        //       new Product
        //       {
        //           Id = 12,
        //           Name = "iPhone 14 Pro Max",
        //           IdCategory = 1,
        //           Price = 129.99m,
        //           IdBrand = 1,
        //           ImgUrl = "https://dam.which.co.uk/IC20006-0248-00-front-2000x1500.jpg",
        //           Description= "iPhone 14 has the same superspeedy chip that's in iPhone 13 Pro. A15 Bionic, with a 5‑core GPU, powers all the latest features and makes graphically intense games and AR apps feel ultrafluid. An updated internal design delivers better thermal efficiency, so you can stay in the action longer."
        //       },
        //       new Product
        //       {
        //           Id = 13,
        //           Name = "iPhone 13",
        //           IdCategory = 1,
        //           Price = 99.99m,
        //           IdBrand = 1,
        //           ImgUrl = "https://ss73.vzw.com/is/image/VerizonWireless/iphone-14-pro-max-deep-purple-fall22-a",
        //           Description = "The iPhone 13 is a smartphone released by Apple in 2021 that features a powerful A15 Bionic chip, 5G connectivity, a ProMotion display, an improved camera system, a Ceramic Shield front cover, and the latest version of Apple's operating system, iOS 15. It is a high-end device that is suitable for a wide range of tasks, including gaming, video streaming, and productivity."
        //       },
        //       new Product
        //       {
        //           Id = 14,
        //           Name = "iPhone 11",
        //           IdCategory = 1,
        //           Price = 69.99m,
        //           IdBrand = 1,
        //           ImgUrl = "https://media.very.co.uk/i/very/V8YI2_SQ1_0000000039_PURPLE_SLf/apple-iphone-14-128gb--nbsppurple.jpg?$180x240_retinamobilex2$&$roundel_very$&p1_img=blank_apple&fmt=webp",
        //           Description = "The iPhone 11 is a budget-friendly smartphone released in 2019 with a 6.1-inch LCD display, dual-camera system, A13 Bionic chip, water and dust resistance, long-lasting battery, and iOS 14 operating system. It is a mid-range device with many of the same features and capabilities as more expensive models."
        //       },
        //        new Product
        //        {
        //            Id = 15,
        //            Name = "iPhone 12",
        //            IdCategory = 1,
        //            Price = 89.99m,
        //            IdBrand = 1,
        //            ImgUrl = "https://media.very.co.uk/i/very/V8YI2_SQ1_0000000039_PURPLE_SLf/apple-iphone-14-128gb--nbsppurple.jpg?$180x240_retinamobilex2$&$roundel_very$&p1_img=blank_apple&fmt=webp",
        //            Description = "The iPhone 12 is a high-end smartphone released in 2020 with a 6.1-inch Super Retina XDR display, dual-camera system, A14 Bionic chip, 5G connectivity, Ceramic Shield front cover, and iOS 14 operating system. It is suitable for a wide range of tasks, including gaming, video streaming, and productivity."
        //        },
        //        new Product
        //        {
        //            Id = 16,
        //            Name = "iPhone 12 Max",
        //            IdCategory = 1,
        //            Price = 95.99m,
        //            IdBrand = 1,
        //            ImgUrl = "https://c.cfjump.com/Products/60101/168787539.jpg",
        //            Description = "The iPhone 12 Max is a high-end smartphone released in 2020 with a 6.7-inch Super Retina XDR display, dual-camera system, A14 Bionic chip, 5G connectivity, Ceramic Shield front cover, and iOS 14 operating system. It is similar to the iPhone 12, but has a larger display and is slightly heavier and wider. It is suitable for a wide range of tasks, including gaming, video streaming, and productivity."
        //        },
        //       new Product
        //       {
        //           Id = 4,
        //           Name = "iPad Pro 12,9",
        //           IdCategory = 2,
        //           Price = 119.99m,
        //           IdBrand = 1,
        //           ImgUrl = "https://cdn.shopify.com/s/files/1/0024/9803/5810/products/580985-Product-0-I-637824105177767213.jpg?v=1653610190",
        //           Description = "The iPad Pro 12.9 is a high-end tablet released by Apple that features a large, 12.9-inch display, fast performance, and advanced features for productivity and creativity. It is powered by a powerful A12Z Bionic chip and includes a ProMotion display with a high refresh rate, as well as a LiDAR scanner for improved AR capabilities. It runs on the latest version of iPadOS and includes a variety of productivity tools and apps. The iPad Pro 12.9 is suitable for demanding tasks such as video editing, 3D design, and gaming."
        //       },
        //       new Product
        //       {
        //           Id = 5,
        //           Name = "Silver Monkey Kabel",
        //           IdCategory = 3,
        //           Price = 9.99m,
        //           IdBrand = 3,
        //           ImgUrl = "https://m.media-amazon.com/images/I/61i6ys+InzL._SL1500_.jpg",
        //           Description = "A wire is a flexible metallic conductor, especially one made of copper, usually insulated, and used to carry electric current in a circuit."

        //       },
        //       new Product
        //       {
        //           Id = 6,
        //           Name = "Microsoft 1850 Mouse",
        //           IdCategory = 3,
        //           Price = 29.99m,
        //           IdBrand = 3,
        //           ImgUrl = "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/peripherals/alienware/peripherals/alienware-trimode-720m-wireless-mouse/assets/mouse-aw720m-wh-gallery-1.psd?fmt=pjpg&pscan=auto&scl=1&wid=4277&hei=3022&qlt=100,1&resMode=sharp2&size=4277,3022&chrss=full&imwidth=5000",
        //           Description = "The Microsoft 1850 Mouse is a budget-friendly, wired mouse with a comfortable, ambidextrous design, three buttons, a scroll wheel, and compatibility with multiple operating systems. It is suitable for basic computing tasks and is both affordable and reliable."
        //       },
        //       new Product
        //       {
        //           Id = 7,
        //           Name = "NuPhy Air75 Red, Gateron",
        //           IdCategory = 3,
        //           Price = 9.99m,
        //           IdBrand = 3,
        //           ImgUrl = "https://m.media-amazon.com/images/I/61KSceiLHwL._SL1500_.jpg",
        //           Description = "It is not possible for me to create a description of the NuPhy Air75 as it is a fictional product that does not exist. I can only provide information about real products that have been released or made available to the public. Please let me know if you have any other questions or if there is anything else I can help with."
        //       },
        //       new Product
        //       {
        //           Id = 8,
        //           Name = "Xiaomi Pad 5",
        //           IdCategory = 2,
        //           Price = 69.99m,
        //           IdBrand = 3,
        //           ImgUrl = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/refurb-ipad-air-wifi-gold-2021?wid=1144&hei=1144&fmt=jpeg&qlt=90&.v=1644268571040",
        //           Description = "The Xiaomi Pad 5 is a budget-friendly tablet with a 10.1-inch Full HD display, Qualcomm Snapdragon 662 processor, 4GB of RAM, 64GB of storage, long-lasting battery, lightweight and portable design, and Android 11 operating system. It is suitable for general use, including web browsing, media consumption, and basic productivity tasks. It offers good performance and a variety of features at an affordable price."
        //       },
        //       new Product
        //       {
        //           Id = 9,
        //           Name = "Galaxy Tab A8",
        //           IdCategory = 2,
        //           Price = 89.99m,
        //           IdBrand = 2,
        //           ImgUrl = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/refurb-ipad-pro-11-wifi-spacegray-2019?wid=1200&hei=630&fmt=jpeg&qlt=95&.v=1581985486323",
        //           Description = "The Samsung Galaxy Tab A8 is a budget-friendly tablet with an 8-inch HD display, octa-core processor, 2GB of RAM, 32GB of storage, long-lasting battery, lightweight and portable design, and Android 10 operating system. It is suitable for general use, including web browsing, media consumption, and basic productivity tasks. It offers good performance and a variety of features at an affordable price."
        //       },
        //       new Product
        //       {
        //           Id = 10,
        //           Name = "Huawei MatePad Paper",
        //           IdCategory = 2,
        //           Price = 89.99m,
        //           IdBrand = 3,
        //           ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQi38H3UrC4gGGRVE_NyPu4hhpQJTBpF0DskBVCK0nJ6JwlA8E813eCPMfdHWNv7kOlsF8&usqp=CAU",
        //           Description = "The Huawei MatePad Paper is a mid-range tablet with a 10.4-inch Full HD display, MediaTek MT8768 processor, 3GB of RAM, 32GB of storage, long-lasting battery, lightweight and portable design, Android 10 operating system, and stylus with 4096 levels of pressure sensitivity. It is specifically designed for use in educational and creative settings, and includes a variety of educational and creative apps pre-installed. It is suitable for tasks such as taking notes, drawing, and writing."
        //       },
        //       new Product
        //       {
        //           Id = 11,
        //           Name = "ASUS RT-AC51",
        //           IdCategory = 3,
        //           Price = 29.99m,
        //           IdBrand = 3,
        //           ImgUrl = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/refurb-ipad-cell-gold-2020?wid=2000&hei=2000&fmt=jpeg&qlt=95&.v=1626465470000",
        //           Description= "The ASUS RT-AC51 is a budget-friendly wireless router with dual-band WiFi, four LAN ports, one WAN port, easy setup, advanced security features, and multiple operating modes. It is suitable for home use and offers good performance and a variety of features."
        //       }
        //    };
        //    return products;
        //}
    }
}
