using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicsStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class orderUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_IdBrand",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_IdCategory",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Orders_IdOrder",
                table: "PurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Products_IdProduct",
                table: "PurchaseItems");

            migrationBuilder.RenameColumn(
                name: "IdProduct",
                table: "PurchaseItems",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "IdOrder",
                table: "PurchaseItems",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseItems_IdProduct",
                table: "PurchaseItems",
                newName: "IX_PurchaseItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseItems_IdOrder",
                table: "PurchaseItems",
                newName: "IX_PurchaseItems_OrderId");

            migrationBuilder.RenameColumn(
                name: "IdCategory",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "IdBrand",
                table: "Products",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_IdCategory",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_IdBrand",
                table: "Products",
                newName: "IX_Products_BrandId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Orders_OrderId",
                table: "PurchaseItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Products_ProductId",
                table: "PurchaseItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Orders_OrderId",
                table: "PurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Products_ProductId",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "PurchaseItems",
                newName: "IdProduct");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "PurchaseItems",
                newName: "IdOrder");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseItems_ProductId",
                table: "PurchaseItems",
                newName: "IX_PurchaseItems_IdProduct");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseItems_OrderId",
                table: "PurchaseItems",
                newName: "IX_PurchaseItems_IdOrder");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "IdCategory");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Products",
                newName: "IdBrand");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_IdCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                newName: "IX_Products_IdBrand");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_IdBrand",
                table: "Products",
                column: "IdBrand",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_IdCategory",
                table: "Products",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Orders_IdOrder",
                table: "PurchaseItems",
                column: "IdOrder",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Products_IdProduct",
                table: "PurchaseItems",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
