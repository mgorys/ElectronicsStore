using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicsStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class description : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "The iPhone 13 Pro Max is Apple's biggest phone in the lineup with a massive, 6.7\" screen that for the first time in an iPhone comes with 120Hz ProMotion display that ensures super smooth scrolling. The benefit of such a gigantic phone is that it also comes with the biggest battery of all iPhone 13 series.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "The OnePlus 9 5G and 9 Pro 5G are Android-based smartphones manufactured by OnePlus, unveiled on March 23, 2021. The phones feature upgraded cameras developed in partnership with Hasselblad.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "The Samsung Galaxy S21 FE is a budget-friendly smartphone released in 2021 that features a 6.5-inch Super AMOLED display, triple camera system, Qualcomm Snapdragon 888 processor, 5G connectivity, long-lasting battery, and Android 11 operating system. It offers many of the same features and capabilities as the more expensive Galaxy S21 models at a more affordable price.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "The iPad Pro 12.9 is a high-end tablet released by Apple that features a large, 12.9-inch display, fast performance, and advanced features for productivity and creativity. It is powered by a powerful A12Z Bionic chip and includes a ProMotion display with a high refresh rate, as well as a LiDAR scanner for improved AR capabilities. It runs on the latest version of iPadOS and includes a variety of productivity tools and apps. The iPad Pro 12.9 is suitable for demanding tasks such as video editing, 3D design, and gaming.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "A wire is a flexible metallic conductor, especially one made of copper, usually insulated, and used to carry electric current in a circuit.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "The Microsoft 1850 Mouse is a budget-friendly, wired mouse with a comfortable, ambidextrous design, three buttons, a scroll wheel, and compatibility with multiple operating systems. It is suitable for basic computing tasks and is both affordable and reliable.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "It is not possible for me to create a description of the NuPhy Air75 as it is a fictional product that does not exist. I can only provide information about real products that have been released or made available to the public. Please let me know if you have any other questions or if there is anything else I can help with.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "The Xiaomi Pad 5 is a budget-friendly tablet with a 10.1-inch Full HD display, Qualcomm Snapdragon 662 processor, 4GB of RAM, 64GB of storage, long-lasting battery, lightweight and portable design, and Android 11 operating system. It is suitable for general use, including web browsing, media consumption, and basic productivity tasks. It offers good performance and a variety of features at an affordable price.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "The Samsung Galaxy Tab A8 is a budget-friendly tablet with an 8-inch HD display, octa-core processor, 2GB of RAM, 32GB of storage, long-lasting battery, lightweight and portable design, and Android 10 operating system. It is suitable for general use, including web browsing, media consumption, and basic productivity tasks. It offers good performance and a variety of features at an affordable price.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "The Huawei MatePad Paper is a mid-range tablet with a 10.4-inch Full HD display, MediaTek MT8768 processor, 3GB of RAM, 32GB of storage, long-lasting battery, lightweight and portable design, Android 10 operating system, and stylus with 4096 levels of pressure sensitivity. It is specifically designed for use in educational and creative settings, and includes a variety of educational and creative apps pre-installed. It is suitable for tasks such as taking notes, drawing, and writing.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "The ASUS RT-AC51 is a budget-friendly wireless router with dual-band WiFi, four LAN ports, one WAN port, easy setup, advanced security features, and multiple operating modes. It is suitable for home use and offers good performance and a variety of features.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "iPhone 14 has the same superspeedy chip that's in iPhone 13 Pro. A15 Bionic, with a 5‑core GPU, powers all the latest features and makes graphically intense games and AR apps feel ultrafluid. An updated internal design delivers better thermal efficiency, so you can stay in the action longer.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "The iPhone 13 is a smartphone released by Apple in 2021 that features a powerful A15 Bionic chip, 5G connectivity, a ProMotion display, an improved camera system, a Ceramic Shield front cover, and the latest version of Apple's operating system, iOS 15. It is a high-end device that is suitable for a wide range of tasks, including gaming, video streaming, and productivity.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "Description",
                value: "The iPhone 11 is a budget-friendly smartphone released in 2019 with a 6.1-inch LCD display, dual-camera system, A13 Bionic chip, water and dust resistance, long-lasting battery, and iOS 14 operating system. It is a mid-range device with many of the same features and capabilities as more expensive models.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "Description",
                value: "The iPhone 12 is a high-end smartphone released in 2020 with a 6.1-inch Super Retina XDR display, dual-camera system, A14 Bionic chip, 5G connectivity, Ceramic Shield front cover, and iOS 14 operating system. It is suitable for a wide range of tasks, including gaming, video streaming, and productivity.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "Description",
                value: "The iPhone 12 Max is a high-end smartphone released in 2020 with a 6.7-inch Super Retina XDR display, dual-camera system, A14 Bionic chip, 5G connectivity, Ceramic Shield front cover, and iOS 14 operating system. It is similar to the iPhone 12, but has a larger display and is slightly heavier and wider. It is suitable for a wide range of tasks, including gaming, video streaming, and productivity.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");
        }
    }
}
