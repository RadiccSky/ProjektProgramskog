using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class AddCvijecarnaToVjencanje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CvijecarnaId",
                table: "Vjenčanje",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 1,
                column: "Kategorija",
                value: "Cvijećarna");

            migrationBuilder.UpdateData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 5,
                column: "Kategorija",
                value: "Cvijećarna");

            migrationBuilder.UpdateData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 6,
                column: "Kategorija",
                value: "Cvijećarna");

            migrationBuilder.UpdateData(
                table: "Vjenčanje",
                keyColumn: "IDVjenčanja",
                keyValue: 1,
                column: "CvijecarnaId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Vjenčanje_CvijecarnaId",
                table: "Vjenčanje",
                column: "CvijecarnaId");

            migrationBuilder.AddForeignKey(
                name: "FK__Vjenčanje__CvijecarnaId",
                table: "Vjenčanje",
                column: "CvijecarnaId",
                principalTable: "Cvijećarna",
                principalColumn: "CvijećarnaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Vjenčanje__CvijecarnaId",
                table: "Vjenčanje");

            migrationBuilder.DropIndex(
                name: "IX_Vjenčanje_CvijecarnaId",
                table: "Vjenčanje");

            migrationBuilder.DropColumn(
                name: "CvijecarnaId",
                table: "Vjenčanje");

            migrationBuilder.UpdateData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 1,
                column: "Kategorija",
                value: "Cvjećarna");

            migrationBuilder.UpdateData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 5,
                column: "Kategorija",
                value: "Cvjećarna");

            migrationBuilder.UpdateData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 6,
                column: "Kategorija",
                value: "Cvjećarna");
        }
    }
}
