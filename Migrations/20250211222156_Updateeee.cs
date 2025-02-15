using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class Updateeee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GlazbenikId",
                table: "Vjenčanje",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Vjenčanje",
                keyColumn: "IDVjenčanja",
                keyValue: 1,
                column: "GlazbenikId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Vjenčanje_GlazbenikId",
                table: "Vjenčanje",
                column: "GlazbenikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vjenčanje_Glazbenici_GlazbenikId",
                table: "Vjenčanje",
                column: "GlazbenikId",
                principalTable: "Glazbenici",
                principalColumn: "GlazbenikID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vjenčanje_Glazbenici_GlazbenikId",
                table: "Vjenčanje");

            migrationBuilder.DropIndex(
                name: "IX_Vjenčanje_GlazbenikId",
                table: "Vjenčanje");

            migrationBuilder.DropColumn(
                name: "GlazbenikId",
                table: "Vjenčanje");
        }
    }
}
