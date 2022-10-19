using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommer.Models.Migrations
{
    public partial class Barang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "url",
                table: "Barangs",
                newName: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Barangs",
                newName: "url");
        }
    }
}
