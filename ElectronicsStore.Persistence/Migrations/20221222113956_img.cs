using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicsStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class img : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://media.4rgos.it/s/Argos/9520103_R_SET?$Main768$&w=620&h=620");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "https://auspost.com.au/shop/static/WFS/AusPost-Shop-Site/-/AusPost-Shop-auspost-B2CWebShop/en_AU/feat-cat/mobile-phones/always-on/category-tiles/MP_UnlockedPhones_3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://www.optus.com.au/content/dam/optus/images/shop/prepaid/phones/optus/optus-x-pro-2/product-tile/OptusXPro2-front-listings.png/renditions/version-1652263444394/original.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "https://cdn.shopify.com/s/files/1/0024/9803/5810/products/580985-Product-0-I-637824105177767213.jpg?v=1653610190");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://m.media-amazon.com/images/I/61i6ys+InzL._SL1500_.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImgUrl",
                value: "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/peripherals/alienware/peripherals/alienware-trimode-720m-wireless-mouse/assets/mouse-aw720m-wh-gallery-1.psd?fmt=pjpg&pscan=auto&scl=1&wid=4277&hei=3022&qlt=100,1&resMode=sharp2&size=4277,3022&chrss=full&imwidth=5000");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImgUrl",
                value: "https://m.media-amazon.com/images/I/61KSceiLHwL._SL1500_.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImgUrl",
                value: "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/refurb-ipad-air-wifi-gold-2021?wid=1144&hei=1144&fmt=jpeg&qlt=90&.v=1644268571040");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImgUrl",
                value: "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/refurb-ipad-pro-11-wifi-spacegray-2019?wid=1200&hei=630&fmt=jpeg&qlt=95&.v=1581985486323");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImgUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQi38H3UrC4gGGRVE_NyPu4hhpQJTBpF0DskBVCK0nJ6JwlA8E813eCPMfdHWNv7kOlsF8&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImgUrl",
                value: "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/refurb-ipad-cell-gold-2020?wid=2000&hei=2000&fmt=jpeg&qlt=95&.v=1626465470000");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImgUrl",
                value: "https://dam.which.co.uk/IC20006-0248-00-front-2000x1500.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImgUrl",
                value: "https://ss73.vzw.com/is/image/VerizonWireless/iphone-14-pro-max-deep-purple-fall22-a");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImgUrl",
                value: "https://media.very.co.uk/i/very/V8YI2_SQ1_0000000039_PURPLE_SLf/apple-iphone-14-128gb--nbsppurple.jpg?$180x240_retinamobilex2$&$roundel_very$&p1_img=blank_apple&fmt=webp");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImgUrl",
                value: "https://media.very.co.uk/i/very/V8YI2_SQ1_0000000039_PURPLE_SLf/apple-iphone-14-128gb--nbsppurple.jpg?$180x240_retinamobilex2$&$roundel_very$&p1_img=blank_apple&fmt=webp");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImgUrl",
                value: "https://c.cfjump.com/Products/60101/168787539.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Products");
        }
    }
}
