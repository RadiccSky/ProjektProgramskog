using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class Dodavanje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Catering",
                table: "Lokacija");

            migrationBuilder.InsertData(
                table: "Partneri",
                columns: new[] { "PartnerID", "BrojTelefona", "Email", "ImePartnera", "Kategorija", "Provizija" },
                values: new object[] { 4, "123-456-789", "beachresort@gmail.com", "Beach Resort", "Lokacija", 0.20m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 4);

            migrationBuilder.AddColumn<bool>(
                name: "Catering",
                table: "Lokacija",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Lokacija",
                keyColumn: "LokacijaID",
                keyValue: 1,
                column: "Catering",
                value: null);
        }
    }
}
