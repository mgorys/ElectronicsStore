using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectronicsStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addBrands : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdBrand",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Apple" },
                    { 2, "Samsung" },
                    { 3, "NoName" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IdBrand", "Name" },
                values: new object[] { 1, "iPhone 13 Pro Max" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IdBrand", "Name" },
                values: new object[] { 3, "OnePlus 9" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IdBrand", "Name" },
                values: new object[] { 2, "Galaxy S21 FE" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IdBrand", "Name" },
                values: new object[] { 1, "iPad Pro 12,9" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IdBrand", "Name" },
                values: new object[] { 3, "Silver Monkey Kabel" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IdBrand", "Name" },
                values: new object[] { 3, "Microsoft 1850 Mouse" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "IdBrand",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "IdBrand", "Name" },
                values: new object[] { 3, "Xiaomi Pad 5" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "IdBrand", "Name" },
                values: new object[] { 2, "Galaxy Tab A8" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "IdBrand", "Name" },
                values: new object[] { 3, "Huawei MatePad Paper" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "IdBrand", "Name" },
                values: new object[] { 3, "ASUS RT-AC51" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdBrand",
                table: "Products",
                column: "IdBrand");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brand_IdBrand",
                table: "Products",
                column: "IdBrand",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brand_IdBrand",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdBrand",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdBrand",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Apple iPhone 13 Pro Max Graphite");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "OnePlus 9 5G Astral Black 120Hz");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Samsung Galaxy S21 FE 5G Fan Edition Grey");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Apple iPad Pro 12,9\" M1 Wi - Fi Space Gray");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Silver Monkey Kabel USB 3.0 - USB-C 1,2m");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Microsoft 1850 Wireless Mobile Mouse");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Xiaomi Pad 5 6/128GB Cosmic Gray 120Hz");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Samsung Galaxy Tab A8 X200 WiFi 4/64GB srebrny");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Huawei MatePad Paper 4/64GB WiFi ");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "ASUS RT-AC51 (750Mb/s a/b/g/n/ac)");
        }
    }
}
