using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class AddHranaIdAndPlaylistIdToVjencanje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HranaId",
                table: "Vjenčanje",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaylistId",
                table: "Vjenčanje",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Vjenčanje",
                keyColumn: "IDVjenčanja",
                keyValue: 1,
                columns: new[] { "HranaId", "PlaylistId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Vjenčanje_HranaId",
                table: "Vjenčanje",
                column: "HranaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vjenčanje_PlaylistId",
                table: "Vjenčanje",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vjenčanje_Hrana_HranaId",
                table: "Vjenčanje",
                column: "HranaId",
                principalTable: "Hrana",
                principalColumn: "HranaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vjenčanje_Playlists_PlaylistId",
                table: "Vjenčanje",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "PlaylistID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vjenčanje_Hrana_HranaId",
                table: "Vjenčanje");

            migrationBuilder.DropForeignKey(
                name: "FK_Vjenčanje_Playlists_PlaylistId",
                table: "Vjenčanje");

            migrationBuilder.DropIndex(
                name: "IX_Vjenčanje_HranaId",
                table: "Vjenčanje");

            migrationBuilder.DropIndex(
                name: "IX_Vjenčanje_PlaylistId",
                table: "Vjenčanje");

            migrationBuilder.DropColumn(
                name: "HranaId",
                table: "Vjenčanje");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Vjenčanje");
        }
    }
}
