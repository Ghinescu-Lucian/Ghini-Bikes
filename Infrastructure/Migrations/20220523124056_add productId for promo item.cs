using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addproductIdforpromoitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromoItems_Products__ProductProductId",
                table: "PromoItems");

            migrationBuilder.RenameColumn(
                name: "_ProductProductId",
                table: "PromoItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PromoItems__ProductProductId",
                table: "PromoItems",
                newName: "IX_PromoItems_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PromoItems_Products_ProductId",
                table: "PromoItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromoItems_Products_ProductId",
                table: "PromoItems");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "PromoItems",
                newName: "_ProductProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PromoItems_ProductId",
                table: "PromoItems",
                newName: "IX_PromoItems__ProductProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PromoItems_Products__ProductProductId",
                table: "PromoItems",
                column: "_ProductProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
