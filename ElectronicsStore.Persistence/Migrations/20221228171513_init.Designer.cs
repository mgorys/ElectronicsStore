// <auto-generated />
using System;
using ElectronicsStore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectronicsStore.Persistence.Migrations
{
    [DbContext(typeof(EStoreDbContext))]
    [Migration("20221228171513_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ElectronicsStore.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = 3,
                            Name = "NoName"
                        });
                });

            modelBuilder.Entity("ElectronicsStore.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Phones"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Devices"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Accesories"
                        });
                });

            modelBuilder.Entity("ElectronicsStore.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("PutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalWorth")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ElectronicsStore.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdBrand")
                        .HasColumnType("int");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdBrand");

                    b.HasIndex("IdCategory");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The iPhone 13 Pro Max is Apple's biggest phone in the lineup with a massive, 6.7\" screen that for the first time in an iPhone comes with 120Hz ProMotion display that ensures super smooth scrolling. The benefit of such a gigantic phone is that it also comes with the biggest battery of all iPhone 13 series.",
                            IdBrand = 1,
                            IdCategory = 1,
                            ImgUrl = "https://media.4rgos.it/s/Argos/9520103_R_SET?$Main768$&w=620&h=620",
                            Name = "iPhone 13 Pro Max",
                            Price = 109.99m
                        },
                        new
                        {
                            Id = 2,
                            Description = "The OnePlus 9 5G and 9 Pro 5G are Android-based smartphones manufactured by OnePlus, unveiled on March 23, 2021. The phones feature upgraded cameras developed in partnership with Hasselblad.",
                            IdBrand = 3,
                            IdCategory = 1,
                            ImgUrl = "https://auspost.com.au/shop/static/WFS/AusPost-Shop-Site/-/AusPost-Shop-auspost-B2CWebShop/en_AU/feat-cat/mobile-phones/always-on/category-tiles/MP_UnlockedPhones_3.jpg",
                            Name = "OnePlus 9",
                            Price = 89.99m
                        },
                        new
                        {
                            Id = 3,
                            Description = "The Samsung Galaxy S21 FE is a budget-friendly smartphone released in 2021 that features a 6.5-inch Super AMOLED display, triple camera system, Qualcomm Snapdragon 888 processor, 5G connectivity, long-lasting battery, and Android 11 operating system. It offers many of the same features and capabilities as the more expensive Galaxy S21 models at a more affordable price.",
                            IdBrand = 2,
                            IdCategory = 1,
                            ImgUrl = "https://www.optus.com.au/content/dam/optus/images/shop/prepaid/phones/optus/optus-x-pro-2/product-tile/OptusXPro2-front-listings.png/renditions/version-1652263444394/original.png",
                            Name = "Galaxy S21 FE",
                            Price = 99.99m
                        },
                        new
                        {
                            Id = 12,
                            Description = "iPhone 14 has the same superspeedy chip that's in iPhone 13 Pro. A15 Bionic, with a 5‑core GPU, powers all the latest features and makes graphically intense games and AR apps feel ultrafluid. An updated internal design delivers better thermal efficiency, so you can stay in the action longer.",
                            IdBrand = 1,
                            IdCategory = 1,
                            ImgUrl = "https://dam.which.co.uk/IC20006-0248-00-front-2000x1500.jpg",
                            Name = "iPhone 14 Pro Max",
                            Price = 129.99m
                        },
                        new
                        {
                            Id = 13,
                            Description = "The iPhone 13 is a smartphone released by Apple in 2021 that features a powerful A15 Bionic chip, 5G connectivity, a ProMotion display, an improved camera system, a Ceramic Shield front cover, and the latest version of Apple's operating system, iOS 15. It is a high-end device that is suitable for a wide range of tasks, including gaming, video streaming, and productivity.",
                            IdBrand = 1,
                            IdCategory = 1,
                            ImgUrl = "https://ss73.vzw.com/is/image/VerizonWireless/iphone-14-pro-max-deep-purple-fall22-a",
                            Name = "iPhone 13",
                            Price = 99.99m
                        },
                        new
                        {
                            Id = 14,
                            Description = "The iPhone 11 is a budget-friendly smartphone released in 2019 with a 6.1-inch LCD display, dual-camera system, A13 Bionic chip, water and dust resistance, long-lasting battery, and iOS 14 operating system. It is a mid-range device with many of the same features and capabilities as more expensive models.",
                            IdBrand = 1,
                            IdCategory = 1,
                            ImgUrl = "https://media.very.co.uk/i/very/V8YI2_SQ1_0000000039_PURPLE_SLf/apple-iphone-14-128gb--nbsppurple.jpg?$180x240_retinamobilex2$&$roundel_very$&p1_img=blank_apple&fmt=webp",
                            Name = "iPhone 11",
                            Price = 69.99m
                        },
                        new
                        {
                            Id = 15,
                            Description = "The iPhone 12 is a high-end smartphone released in 2020 with a 6.1-inch Super Retina XDR display, dual-camera system, A14 Bionic chip, 5G connectivity, Ceramic Shield front cover, and iOS 14 operating system. It is suitable for a wide range of tasks, including gaming, video streaming, and productivity.",
                            IdBrand = 1,
                            IdCategory = 1,
                            ImgUrl = "https://media.very.co.uk/i/very/V8YI2_SQ1_0000000039_PURPLE_SLf/apple-iphone-14-128gb--nbsppurple.jpg?$180x240_retinamobilex2$&$roundel_very$&p1_img=blank_apple&fmt=webp",
                            Name = "iPhone 12",
                            Price = 89.99m
                        },
                        new
                        {
                            Id = 16,
                            Description = "The iPhone 12 Max is a high-end smartphone released in 2020 with a 6.7-inch Super Retina XDR display, dual-camera system, A14 Bionic chip, 5G connectivity, Ceramic Shield front cover, and iOS 14 operating system. It is similar to the iPhone 12, but has a larger display and is slightly heavier and wider. It is suitable for a wide range of tasks, including gaming, video streaming, and productivity.",
                            IdBrand = 1,
                            IdCategory = 1,
                            ImgUrl = "https://c.cfjump.com/Products/60101/168787539.jpg",
                            Name = "iPhone 12 Max",
                            Price = 95.99m
                        },
                        new
                        {
                            Id = 4,
                            Description = "The iPad Pro 12.9 is a high-end tablet released by Apple that features a large, 12.9-inch display, fast performance, and advanced features for productivity and creativity. It is powered by a powerful A12Z Bionic chip and includes a ProMotion display with a high refresh rate, as well as a LiDAR scanner for improved AR capabilities. It runs on the latest version of iPadOS and includes a variety of productivity tools and apps. The iPad Pro 12.9 is suitable for demanding tasks such as video editing, 3D design, and gaming.",
                            IdBrand = 1,
                            IdCategory = 2,
                            ImgUrl = "https://cdn.shopify.com/s/files/1/0024/9803/5810/products/580985-Product-0-I-637824105177767213.jpg?v=1653610190",
                            Name = "iPad Pro 12,9",
                            Price = 119.99m
                        },
                        new
                        {
                            Id = 5,
                            Description = "A wire is a flexible metallic conductor, especially one made of copper, usually insulated, and used to carry electric current in a circuit.",
                            IdBrand = 3,
                            IdCategory = 3,
                            ImgUrl = "https://m.media-amazon.com/images/I/61i6ys+InzL._SL1500_.jpg",
                            Name = "Silver Monkey Kabel",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = 6,
                            Description = "The Microsoft 1850 Mouse is a budget-friendly, wired mouse with a comfortable, ambidextrous design, three buttons, a scroll wheel, and compatibility with multiple operating systems. It is suitable for basic computing tasks and is both affordable and reliable.",
                            IdBrand = 3,
                            IdCategory = 3,
                            ImgUrl = "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/peripherals/alienware/peripherals/alienware-trimode-720m-wireless-mouse/assets/mouse-aw720m-wh-gallery-1.psd?fmt=pjpg&pscan=auto&scl=1&wid=4277&hei=3022&qlt=100,1&resMode=sharp2&size=4277,3022&chrss=full&imwidth=5000",
                            Name = "Microsoft 1850 Mouse",
                            Price = 29.99m
                        },
                        new
                        {
                            Id = 7,
                            Description = "It is not possible for me to create a description of the NuPhy Air75 as it is a fictional product that does not exist. I can only provide information about real products that have been released or made available to the public. Please let me know if you have any other questions or if there is anything else I can help with.",
                            IdBrand = 3,
                            IdCategory = 3,
                            ImgUrl = "https://m.media-amazon.com/images/I/61KSceiLHwL._SL1500_.jpg",
                            Name = "NuPhy Air75 Red, Gateron",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = 8,
                            Description = "The Xiaomi Pad 5 is a budget-friendly tablet with a 10.1-inch Full HD display, Qualcomm Snapdragon 662 processor, 4GB of RAM, 64GB of storage, long-lasting battery, lightweight and portable design, and Android 11 operating system. It is suitable for general use, including web browsing, media consumption, and basic productivity tasks. It offers good performance and a variety of features at an affordable price.",
                            IdBrand = 3,
                            IdCategory = 2,
                            ImgUrl = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/refurb-ipad-air-wifi-gold-2021?wid=1144&hei=1144&fmt=jpeg&qlt=90&.v=1644268571040",
                            Name = "Xiaomi Pad 5",
                            Price = 69.99m
                        },
                        new
                        {
                            Id = 9,
                            Description = "The Samsung Galaxy Tab A8 is a budget-friendly tablet with an 8-inch HD display, octa-core processor, 2GB of RAM, 32GB of storage, long-lasting battery, lightweight and portable design, and Android 10 operating system. It is suitable for general use, including web browsing, media consumption, and basic productivity tasks. It offers good performance and a variety of features at an affordable price.",
                            IdBrand = 2,
                            IdCategory = 2,
                            ImgUrl = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/refurb-ipad-pro-11-wifi-spacegray-2019?wid=1200&hei=630&fmt=jpeg&qlt=95&.v=1581985486323",
                            Name = "Galaxy Tab A8",
                            Price = 89.99m
                        },
                        new
                        {
                            Id = 10,
                            Description = "The Huawei MatePad Paper is a mid-range tablet with a 10.4-inch Full HD display, MediaTek MT8768 processor, 3GB of RAM, 32GB of storage, long-lasting battery, lightweight and portable design, Android 10 operating system, and stylus with 4096 levels of pressure sensitivity. It is specifically designed for use in educational and creative settings, and includes a variety of educational and creative apps pre-installed. It is suitable for tasks such as taking notes, drawing, and writing.",
                            IdBrand = 3,
                            IdCategory = 2,
                            ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQi38H3UrC4gGGRVE_NyPu4hhpQJTBpF0DskBVCK0nJ6JwlA8E813eCPMfdHWNv7kOlsF8&usqp=CAU",
                            Name = "Huawei MatePad Paper",
                            Price = 89.99m
                        },
                        new
                        {
                            Id = 11,
                            Description = "The ASUS RT-AC51 is a budget-friendly wireless router with dual-band WiFi, four LAN ports, one WAN port, easy setup, advanced security features, and multiple operating modes. It is suitable for home use and offers good performance and a variety of features.",
                            IdBrand = 3,
                            IdCategory = 3,
                            ImgUrl = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/refurb-ipad-cell-gold-2020?wid=2000&hei=2000&fmt=jpeg&qlt=95&.v=1626465470000",
                            Name = "ASUS RT-AC51",
                            Price = 29.99m
                        });
                });

            modelBuilder.Entity("ElectronicsStore.Entities.PurchaseItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdOrder");

                    b.HasIndex("IdProduct");

                    b.ToTable("PurchaseItems");
                });

            modelBuilder.Entity("ElectronicsStore.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ElectronicsStore.Entities.Product", b =>
                {
                    b.HasOne("ElectronicsStore.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("IdBrand")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicsStore.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ElectronicsStore.Entities.PurchaseItem", b =>
                {
                    b.HasOne("ElectronicsStore.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicsStore.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
