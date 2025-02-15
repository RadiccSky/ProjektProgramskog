using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class AddLokacijaToVjencanje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LokacijaId",
                table: "Vjenčanje",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Vjenčanje",
                keyColumn: "IDVjenčanja",
                keyValue: 1,
                column: "LokacijaId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Vjenčanje_LokacijaId",
                table: "Vjenčanje",
                column: "LokacijaId");

            migrationBuilder.AddForeignKey(
                name: "FK__Vjenčanje__LokacijaId",
                table: "Vjenčanje",
                column: "LokacijaId",
                principalTable: "Lokacija",
                principalColumn: "LokacijaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Vjenčanje__LokacijaId",
                table: "Vjenčanje");

            migrationBuilder.DropIndex(
                name: "IX_Vjenčanje_LokacijaId",
                table: "Vjenčanje");

            migrationBuilder.DropColumn(
                name: "LokacijaId",
                table: "Vjenčanje");
        }
    }
}
