using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Playlists__Glazb__5629CD9C",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_GlazbenikID",
                table: "Playlists");

            migrationBuilder.AddColumn<int>(
                name: "GlazbeniciGlazbenikId",
                table: "Playlists",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 1,
                column: "GlazbeniciGlazbenikId",
                value: null);

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "PlaylistID", "GlazbeniciGlazbenikId", "GlazbenikID", "ListPjesama" },
                values: new object[,]
                {
                    { 2, null, 1, "Song 5, Song 6, Song 7" },
                    { 3, null, 1, "Song 5, Song 6, Song 7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_GlazbeniciGlazbenikId",
                table: "Playlists",
                column: "GlazbeniciGlazbenikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Glazbenici_GlazbeniciGlazbenikId",
                table: "Playlists",
                column: "GlazbeniciGlazbenikId",
                principalTable: "Glazbenici",
                principalColumn: "GlazbenikID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Glazbenici_GlazbeniciGlazbenikId",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_GlazbeniciGlazbenikId",
                table: "Playlists");

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "GlazbeniciGlazbenikId",
                table: "Playlists");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_GlazbenikID",
                table: "Playlists",
                column: "GlazbenikID");

            migrationBuilder.AddForeignKey(
                name: "FK__Playlists__Glazb__5629CD9C",
                table: "Playlists",
                column: "GlazbenikID",
                principalTable: "Glazbenici",
                principalColumn: "GlazbenikID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
