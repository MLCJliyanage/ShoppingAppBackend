using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingApp.Data.Migrations
{
    public partial class deleterestrict3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sha_Products_Sha_Manufactureres_ManufacturerId",
                table: "Sha_Products");

            migrationBuilder.DropIndex(
                name: "IX_Sha_Products_ManufacturerId",
                table: "Sha_Products");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Sha_Products");

            migrationBuilder.DropColumn(
                name: "ManufacturerId1",
                table: "Sha_Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Sha_Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId1",
                table: "Sha_Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sha_Products_ManufacturerId",
                table: "Sha_Products",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sha_Products_Sha_Manufactureres_ManufacturerId",
                table: "Sha_Products",
                column: "ManufacturerId",
                principalTable: "Sha_Manufactureres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
