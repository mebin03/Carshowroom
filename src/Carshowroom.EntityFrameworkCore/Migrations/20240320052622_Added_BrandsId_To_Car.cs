using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carshowroom.Migrations
{
    /// <inheritdoc />
    public partial class Added_BrandsId_To_Car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BrandsId",
                table: "AppCars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppCars_BrandsId",
                table: "AppCars",
                column: "BrandsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCars_AppBrands_BrandsId",
                table: "AppCars",
                column: "BrandsId",
                principalTable: "AppBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCars_AppBrands_BrandsId",
                table: "AppCars");

            migrationBuilder.DropIndex(
                name: "IX_AppCars_BrandsId",
                table: "AppCars");

            migrationBuilder.DropColumn(
                name: "BrandsId",
                table: "AppCars");
        }
    }
}
