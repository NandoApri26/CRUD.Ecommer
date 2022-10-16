using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecommer.Models.Migrations
{
    public partial class TablePembeli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PembeliIdPembeli",
                table: "Barangs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pembelis",
                columns: table => new
                {
                    IdPembeli = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Alamat = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NoHp = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Negara = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    IdUser = table.Column<int>(type: "integer", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pembelis", x => x.IdPembeli);
                    table.ForeignKey(
                        name: "FK_Pembelis_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barangs_PembeliIdPembeli",
                table: "Barangs",
                column: "PembeliIdPembeli");

            migrationBuilder.CreateIndex(
                name: "IX_Pembelis_IdUser",
                table: "Pembelis",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Barangs_Pembelis_PembeliIdPembeli",
                table: "Barangs",
                column: "PembeliIdPembeli",
                principalTable: "Pembelis",
                principalColumn: "IdPembeli");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barangs_Pembelis_PembeliIdPembeli",
                table: "Barangs");

            migrationBuilder.DropTable(
                name: "Pembelis");

            migrationBuilder.DropIndex(
                name: "IX_Barangs_PembeliIdPembeli",
                table: "Barangs");

            migrationBuilder.DropColumn(
                name: "PembeliIdPembeli",
                table: "Barangs");
        }
    }
}
