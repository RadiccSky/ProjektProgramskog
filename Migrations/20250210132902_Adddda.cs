using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class Adddda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 1,
                column: "ListPjesama",
                value: "Narodna");

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 2,
                column: "ListPjesama",
                value: "Folk");

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 3,
                column: "ListPjesama",
                value: "Pop");

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "PlaylistID", "GlazbeniciGlazbenikId", "GlazbenikID", "ListPjesama" },
                values: new object[,]
                {
                    { 4, null, 2, "Narodna" },
                    { 5, null, 2, "Folk" },
                    { 6, null, 2, "Pop" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 1,
                column: "ListPjesama",
                value: "Song 1, Song 2, Song 3");

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 2,
                column: "ListPjesama",
                value: "Song 5, Song 6, Song 7");

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 3,
                column: "ListPjesama",
                value: "Song 5, Song 6, Song 7");
        }
    }
}
