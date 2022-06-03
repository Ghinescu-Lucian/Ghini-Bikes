using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class updateorderItem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_OrderItems_OrderItemId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_OrderItemId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_OrderItemId",
                table: "Images",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_OrderItems_OrderItemId",
                table: "Images",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id");
        }
    }
}
