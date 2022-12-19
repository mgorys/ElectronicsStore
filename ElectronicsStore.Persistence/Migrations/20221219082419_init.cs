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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "IdCategory", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Apple iPhone 13 Pro Max Graphite", 109.99m },
                    { 2, 1, "OnePlus 9 5G Astral Black 120Hz", 89.99m },
                    { 3, 1, "Samsung Galaxy S21 FE 5G Fan Edition Grey", 99.99m },
                    { 4, 2, "Apple iPad Pro 12,9\" M1 Wi - Fi Space Gray", 119.99m },
                    { 5, 3, "Silver Monkey Kabel USB 3.0 - USB-C 1,2m", 9.99m },
                    { 6, 3, "Microsoft 1850 Wireless Mobile Mouse", 29.99m },
                    { 7, 3, "NuPhy Air75 Red, Gateron", 9.99m },
                    { 8, 2, "Xiaomi Pad 5 6/128GB Cosmic Gray 120Hz", 69.99m },
                    { 9, 2, "Samsung Galaxy Tab A8 X200 WiFi 4/64GB srebrny", 89.99m },
                    { 10, 2, "Huawei MatePad Paper 4/64GB WiFi ", 89.99m },
                    { 11, 3, "ASUS RT-AC51 (750Mb/s a/b/g/n/ac)", 29.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCategory",
                table: "Products",
                column: "IdCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
