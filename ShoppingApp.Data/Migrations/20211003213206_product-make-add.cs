using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingApp.Data.Migrations
{
    public partial class productmakeadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Manufacturer_id",
                table: "Sha_Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sha_Manufactureres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sha_Manufactureres", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sha_Products_Manufacturer_id",
                table: "Sha_Products",
                column: "Manufacturer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sha_Products_Sha_Manufactureres_Manufacturer_id",
                table: "Sha_Products",
                column: "Manufacturer_id",
                principalTable: "Sha_Manufactureres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sha_Products_Sha_Manufactureres_Manufacturer_id",
                table: "Sha_Products");

            migrationBuilder.DropTable(
                name: "Sha_Manufactureres");

            migrationBuilder.DropIndex(
                name: "IX_Sha_Products_Manufacturer_id",
                table: "Sha_Products");

            migrationBuilder.DropColumn(
                name: "Manufacturer_id",
                table: "Sha_Products");
        }
    }
}
