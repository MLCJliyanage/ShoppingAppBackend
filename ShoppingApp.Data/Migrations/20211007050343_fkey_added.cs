using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingApp.Data.Migrations
{
    public partial class fkey_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sha_Products_AddedUserId",
                table: "Sha_Products",
                column: "AddedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sha_Products_AspNetUsers_AddedUserId",
                table: "Sha_Products",
                column: "AddedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sha_Products_AspNetUsers_AddedUserId",
                table: "Sha_Products");

            migrationBuilder.DropIndex(
                name: "IX_Sha_Products_AddedUserId",
                table: "Sha_Products");
        }
    }
}
