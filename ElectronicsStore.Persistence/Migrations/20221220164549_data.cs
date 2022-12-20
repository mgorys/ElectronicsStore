using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectronicsStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Id", "IdBrand", "IdCategory", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, "iPhone 13 Pro Max", 109.99m },
                    { 2, 3, 1, "OnePlus 9", 89.99m },
                    { 3, 2, 1, "Galaxy S21 FE", 99.99m },
                    { 4, 1, 2, "iPad Pro 12,9", 119.99m },
                    { 5, 3, 3, "Silver Monkey Kabel", 9.99m },
                    { 6, 3, 3, "Microsoft 1850 Mouse", 29.99m },
                    { 7, 3, 3, "NuPhy Air75 Red, Gateron", 9.99m },
                    { 8, 3, 2, "Xiaomi Pad 5", 69.99m },
                    { 9, 2, 2, "Galaxy Tab A8", 89.99m },
                    { 10, 3, 2, "Huawei MatePad Paper", 89.99m },
                    { 11, 3, 3, "ASUS RT-AC51", 29.99m },
                    { 12, 1, 1, "iPhone 14 Pro Max", 129.99m },
                    { 13, 1, 1, "iPhone 13", 99.99m },
                    { 14, 1, 1, "iPhone 11", 69.99m },
                    { 15, 1, 1, "iPhone 12", 89.99m },
                    { 16, 1, 1, "iPhone 12 Max", 95.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
