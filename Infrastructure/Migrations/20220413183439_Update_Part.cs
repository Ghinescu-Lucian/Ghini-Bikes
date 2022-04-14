﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Update_Part : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartProductId",
                table: "Products",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
