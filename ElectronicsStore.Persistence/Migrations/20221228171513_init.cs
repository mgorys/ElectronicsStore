using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectronicsStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalWorth = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    IdBrand = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_IdBrand",
                        column: x => x.IdBrand,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Apple" },
                    { 2, "Samsung" },
                    { 3, "NoName" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Phones" },
                    { 2, "Devices" },
                    { 3, "Accesories" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IdBrand", "IdCategory", "ImgUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "The iPhone 13 Pro Max is Apple's biggest phone in the lineup with a massive, 6.7\" screen that for the first time in an iPhone comes with 120Hz ProMotion display that ensures super smooth scrolling. The benefit of such a gigantic phone is that it also comes with the biggest battery of all iPhone 13 series.", 1, 1, "https://media.4rgos.it/s/Argos/9520103_R_SET?$Main768$&w=620&h=620", "iPhone 13 Pro Max", 109.99m },
                    { 2, "The OnePlus 9 5G and 9 Pro 5G are Android-based smartphones manufactured by OnePlus, unveiled on March 23, 2021. The phones feature upgraded cameras developed in partnership with Hasselblad.", 3, 1, "https://auspost.com.au/shop/static/WFS/AusPost-Shop-Site/-/AusPost-Shop-auspost-B2CWebShop/en_AU/feat-cat/mobile-phones/always-on/category-tiles/MP_UnlockedPhones_3.jpg", "OnePlus 9", 89.99m },
                    { 3, "The Samsung Galaxy S21 FE is a budget-friendly smartphone released in 2021 that features a 6.5-inch Super AMOLED display, triple camera system, Qualcomm Snapdragon 888 processor, 5G connectivity, long-lasting battery, and Android 11 operating system. It offers many of the same features and capabilities as the more expensive Galaxy S21 models at a more affordable price.", 2, 1, "https://www.optus.com.au/content/dam/optus/images/shop/prepaid/phones/optus/optus-x-pro-2/product-tile/OptusXPro2-front-listings.png/renditions/version-1652263444394/original.png", "Galaxy S21 FE", 99.99m },
                    { 4, "The iPad Pro 12.9 is a high-end tablet released by Apple that features a large, 12.9-inch display, fast performance, and advanced features for productivity and creativity. It is powered by a powerful A12Z Bionic chip and includes a ProMotion display with a high refresh rate, as well as a LiDAR scanner for improved AR capabilities. It runs on the latest version of iPadOS and includes a variety of productivity tools and apps. The iPad Pro 12.9 is suitable for demanding tasks such as video editing, 3D design, and gaming.", 1, 2, "https://cdn.shopify.com/s/files/1/0024/9803/5810/products/580985-Product-0-I-637824105177767213.jpg?v=1653610190", "iPad Pro 12,9", 119.99m },
                    { 5, "A wire is a flexible metallic conductor, especially one made of copper, usually insulated, and used to carry electric current in a circuit.", 3, 3, "https://m.media-amazon.com/images/I/61i6ys+InzL._SL1500_.jpg", "Silver Monkey Kabel", 9.99m },
                    { 6, "The Microsoft 1850 Mouse is a budget-friendly, wired mouse with a comfortable, ambidextrous design, three buttons, a scroll wheel, and compatibility with multiple operating systems. It is suitable for basic computing tasks and is both affordable and reliable.", 3, 3, "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/peripherals/alienware/peripherals/alienware-trimode-720m-wireless-mouse/assets/mouse-aw720m-wh-gallery-1.psd?fmt=pjpg&pscan=auto&scl=1&wid=4277&hei=3022&qlt=100,1&resMode=sharp2&size=4277,3022&chrss=full&imwidth=5000", "Microsoft 1850 Mouse", 29.99m },
                    { 7, "It is not possible for me to create a description of the NuPhy Air75 as it is a fictional product that does not exist. I can only provide information about real products that have been released or made available to the public. Please let me know if you have any other questions or if there is anything else I can help with.", 3, 3, "https://m.media-amazon.com/images/I/61KSceiLHwL._SL1500_.jpg", "NuPhy Air75 Red, Gateron", 9.99m },
                    { 8, "The Xiaomi Pad 5 is a budget-friendly tablet with a 10.1-inch Full HD display, Qualcomm Snapdragon 662 processor, 4GB of RAM, 64GB of storage, long-lasting battery, lightweight and portable design, and Android 11 operating system. It is suitable for general use, including web browsing, media consumption, and basic productivity tasks. It offers good performance and a variety of features at an affordable price.", 3, 2, "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/refurb-ipad-air-wifi-gold-2021?wid=1144&hei=1144&fmt=jpeg&qlt=90&.v=1644268571040", "Xiaomi Pad 5", 69.99m },
                    { 9, "The Samsung Galaxy Tab A8 is a budget-friendly tablet with an 8-inch HD display, octa-core processor, 2GB of RAM, 32GB of storage, long-lasting battery, lightweight and portable design, and Android 10 operating system. It is suitable for general use, including web browsing, media consumption, and basic productivity tasks. It offers good performance and a variety of features at an affordable price.", 2, 2, "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/refurb-ipad-pro-11-wifi-spacegray-2019?wid=1200&hei=630&fmt=jpeg&qlt=95&.v=1581985486323", "Galaxy Tab A8", 89.99m },
                    { 10, "The Huawei MatePad Paper is a mid-range tablet with a 10.4-inch Full HD display, MediaTek MT8768 processor, 3GB of RAM, 32GB of storage, long-lasting battery, lightweight and portable design, Android 10 operating system, and stylus with 4096 levels of pressure sensitivity. It is specifically designed for use in educational and creative settings, and includes a variety of educational and creative apps pre-installed. It is suitable for tasks such as taking notes, drawing, and writing.", 3, 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQi38H3UrC4gGGRVE_NyPu4hhpQJTBpF0DskBVCK0nJ6JwlA8E813eCPMfdHWNv7kOlsF8&usqp=CAU", "Huawei MatePad Paper", 89.99m },
                    { 11, "The ASUS RT-AC51 is a budget-friendly wireless router with dual-band WiFi, four LAN ports, one WAN port, easy setup, advanced security features, and multiple operating modes. It is suitable for home use and offers good performance and a variety of features.", 3, 3, "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/refurb-ipad-cell-gold-2020?wid=2000&hei=2000&fmt=jpeg&qlt=95&.v=1626465470000", "ASUS RT-AC51", 29.99m },
                    { 12, "iPhone 14 has the same superspeedy chip that's in iPhone 13 Pro. A15 Bionic, with a 5‑core GPU, powers all the latest features and makes graphically intense games and AR apps feel ultrafluid. An updated internal design delivers better thermal efficiency, so you can stay in the action longer.", 1, 1, "https://dam.which.co.uk/IC20006-0248-00-front-2000x1500.jpg", "iPhone 14 Pro Max", 129.99m },
                    { 13, "The iPhone 13 is a smartphone released by Apple in 2021 that features a powerful A15 Bionic chip, 5G connectivity, a ProMotion display, an improved camera system, a Ceramic Shield front cover, and the latest version of Apple's operating system, iOS 15. It is a high-end device that is suitable for a wide range of tasks, including gaming, video streaming, and productivity.", 1, 1, "https://ss73.vzw.com/is/image/VerizonWireless/iphone-14-pro-max-deep-purple-fall22-a", "iPhone 13", 99.99m },
                    { 14, "The iPhone 11 is a budget-friendly smartphone released in 2019 with a 6.1-inch LCD display, dual-camera system, A13 Bionic chip, water and dust resistance, long-lasting battery, and iOS 14 operating system. It is a mid-range device with many of the same features and capabilities as more expensive models.", 1, 1, "https://media.very.co.uk/i/very/V8YI2_SQ1_0000000039_PURPLE_SLf/apple-iphone-14-128gb--nbsppurple.jpg?$180x240_retinamobilex2$&$roundel_very$&p1_img=blank_apple&fmt=webp", "iPhone 11", 69.99m },
                    { 15, "The iPhone 12 is a high-end smartphone released in 2020 with a 6.1-inch Super Retina XDR display, dual-camera system, A14 Bionic chip, 5G connectivity, Ceramic Shield front cover, and iOS 14 operating system. It is suitable for a wide range of tasks, including gaming, video streaming, and productivity.", 1, 1, "https://media.very.co.uk/i/very/V8YI2_SQ1_0000000039_PURPLE_SLf/apple-iphone-14-128gb--nbsppurple.jpg?$180x240_retinamobilex2$&$roundel_very$&p1_img=blank_apple&fmt=webp", "iPhone 12", 89.99m },
                    { 16, "The iPhone 12 Max is a high-end smartphone released in 2020 with a 6.7-inch Super Retina XDR display, dual-camera system, A14 Bionic chip, 5G connectivity, Ceramic Shield front cover, and iOS 14 operating system. It is similar to the iPhone 12, but has a larger display and is slightly heavier and wider. It is suitable for a wide range of tasks, including gaming, video streaming, and productivity.", 1, 1, "https://c.cfjump.com/Products/60101/168787539.jpg", "iPhone 12 Max", 95.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdBrand",
                table: "Products",
                column: "IdBrand");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCategory",
                table: "Products",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_IdOrder",
                table: "PurchaseItems",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_IdProduct",
                table: "PurchaseItems",
                column: "IdProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
