using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class udpateadsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Lokacija",
                keyColumn: "LokacijaID",
                keyValue: 1,
                column: "Ime",
                value: "Bijela Ruža");

            migrationBuilder.InsertData(
                table: "Lokacija",
                columns: new[] { "LokacijaID", "CijenaPoDanu", "Ime", "PartnerID" },
                values: new object[,]
                {
                    { 2, 1500.00m, "Vjenčana Oaza", 1 },
                    { 3, 1500.00m, "Bajka", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 4,
                columns: new[] { "Email", "ImePartnera" },
                values: new object[] { "bijelaruza", "Bijela Ruža" });

            migrationBuilder.InsertData(
                table: "Partneri",
                columns: new[] { "PartnerID", "BrojTelefona", "Email", "ImePartnera", "Kategorija", "Provizija" },
                values: new object[,]
                {
                    { 8, "123-456-789", "vjenčanaoaza", "Vjenčana Oaza", "Lokacija", null },
                    { 9, "123-456-789", "bajka", "Bajka", "Lokacija", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lokacija",
                keyColumn: "LokacijaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lokacija",
                keyColumn: "LokacijaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Lokacija",
                keyColumn: "LokacijaID",
                keyValue: 1,
                column: "Ime",
                value: "Beach Resort");

            migrationBuilder.UpdateData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 4,
                columns: new[] { "Email", "ImePartnera" },
                values: new object[] { "beachresort@gmail.com", "Beach Resort" });
        }
    }
}
