using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class AddHranaFieldsToVjencanje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vjenčanje_Hrana_HranaId",
                table: "Vjenčanje");

            migrationBuilder.RenameColumn(
                name: "HranaId",
                table: "Vjenčanje",
                newName: "PredjeloId");

            migrationBuilder.RenameIndex(
                name: "IX_Vjenčanje_HranaId",
                table: "Vjenčanje",
                newName: "IX_Vjenčanje_PredjeloId");

            migrationBuilder.AddColumn<int>(
                name: "DesertId",
                table: "Vjenčanje",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GlavnoJeloId",
                table: "Vjenčanje",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Vjenčanje",
                keyColumn: "IDVjenčanja",
                keyValue: 1,
                columns: new[] { "DesertId", "GlavnoJeloId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Vjenčanje_DesertId",
                table: "Vjenčanje",
                column: "DesertId");

            migrationBuilder.CreateIndex(
                name: "IX_Vjenčanje_GlavnoJeloId",
                table: "Vjenčanje",
                column: "GlavnoJeloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vjenčanje_Hrana_DesertId",
                table: "Vjenčanje",
                column: "DesertId",
                principalTable: "Hrana",
                principalColumn: "HranaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vjenčanje_Hrana_GlavnoJeloId",
                table: "Vjenčanje",
                column: "GlavnoJeloId",
                principalTable: "Hrana",
                principalColumn: "HranaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vjenčanje_Hrana_PredjeloId",
                table: "Vjenčanje",
                column: "PredjeloId",
                principalTable: "Hrana",
                principalColumn: "HranaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vjenčanje_Hrana_DesertId",
                table: "Vjenčanje");

            migrationBuilder.DropForeignKey(
                name: "FK_Vjenčanje_Hrana_GlavnoJeloId",
                table: "Vjenčanje");

            migrationBuilder.DropForeignKey(
                name: "FK_Vjenčanje_Hrana_PredjeloId",
                table: "Vjenčanje");

            migrationBuilder.DropIndex(
                name: "IX_Vjenčanje_DesertId",
                table: "Vjenčanje");

            migrationBuilder.DropIndex(
                name: "IX_Vjenčanje_GlavnoJeloId",
                table: "Vjenčanje");

            migrationBuilder.DropColumn(
                name: "DesertId",
                table: "Vjenčanje");

            migrationBuilder.DropColumn(
                name: "GlavnoJeloId",
                table: "Vjenčanje");

            migrationBuilder.RenameColumn(
                name: "PredjeloId",
                table: "Vjenčanje",
                newName: "HranaId");

            migrationBuilder.RenameIndex(
                name: "IX_Vjenčanje_PredjeloId",
                table: "Vjenčanje",
                newName: "IX_Vjenčanje_HranaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vjenčanje_Hrana_HranaId",
                table: "Vjenčanje",
                column: "HranaId",
                principalTable: "Hrana",
                principalColumn: "HranaID");
        }
    }
}
