using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Add_CompatibleItem_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_PartProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PartProductId",
                table: "Products");

        

            migrationBuilder.DropColumn(
                name: "PartProductId",
                table: "Products");


           

            

            migrationBuilder.CreateTable(
                name: "Compatibilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeProductId = table.Column<int>(type: "int", nullable: false),
                    PartProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compatibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compatibilities_Products_BikeProductId",
                        column: x => x.BikeProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compatibilities_Products_PartProductId",
                        column: x => x.PartProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compatibilities_BikeProductId",
                table: "Compatibilities",
                column: "BikeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Compatibilities_PartProductId",
                table: "Compatibilities",
                column: "PartProductId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

           
            migrationBuilder.AddColumn<int>(
                name: "PartProductId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Image",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");


            migrationBuilder.CreateIndex(
                name: "IX_Products_PartProductId",
                table: "Products",
                column: "PartProductId");


            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_PartProductId",
                table: "Products",
                column: "PartProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }
    }
}
