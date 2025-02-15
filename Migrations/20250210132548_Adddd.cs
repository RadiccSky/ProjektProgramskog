using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class Adddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cvijećarna",
                keyColumn: "CvijećarnaID",
                keyValue: 1,
                column: "Ime",
                value: "Cvjetna oaza");

            migrationBuilder.InsertData(
                table: "Cvijećarna",
                columns: new[] { "CvijećarnaID", "Cijena", "Detalji", "Ime", "PartnerID" },
                values: new object[,]
                {
                    { 2, 650m, null, "Cvijecarna Ana", 2 },
                    { 3, 700m, null, "Buket snova", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Hrana",
                keyColumn: "HranaID",
                keyValue: 1,
                column: "Naziv",
                value: "Teleći Medaljoni");

            migrationBuilder.UpdateData(
                table: "Hrana",
                keyColumn: "HranaID",
                keyValue: 2,
                columns: new[] { "CijenaPoOsobi", "Naziv", "TipHrane" },
                values: new object[] { 40.00m, "Pečena janjetina s krumpirima", "Glavno jelo" });

            migrationBuilder.InsertData(
                table: "Hrana",
                columns: new[] { "HranaID", "CijenaPoOsobi", "Detalji", "Naziv", "PartnerID", "TipHrane" },
                values: new object[,]
                {
                    { 3, 60.00m, null, "Pečena patka s mlincima", 1, "Glavno jelo" },
                    { 4, 10.00m, null, "Cheesecake", 1, "Desert" },
                    { 5, 11.00m, null, "Baklava", 1, "Desert" },
                    { 6, 9.00m, null, "Čokoladni lava cake", 1, "Desert" },
                    { 7, 20.00m, null, "Rolana puretina ili piletina punjena sirom i šunkom", 1, "Predjelo" },
                    { 8, 15.00m, null, "Tart od sira i špinata", 1, "Predjelo" },
                    { 9, 11.00m, null, "Juha", 1, "Predjelo" }
                });

            migrationBuilder.UpdateData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 1,
                column: "ImePartnera",
                value: "Cvjetna oaza");

            migrationBuilder.InsertData(
                table: "Partneri",
                columns: new[] { "PartnerID", "BrojTelefona", "Email", "ImePartnera", "Kategorija", "Provizija" },
                values: new object[,]
                {
                    { 5, "063-111-333", "info@floraldreams.com", "Buket snova", "Cvjećarna", 0.10m },
                    { 6, "063-111-222", "info@floraldreams.com", "Cvijecarna Ana", "Cvjećarna", 0.10m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cvijećarna",
                keyColumn: "CvijećarnaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cvijećarna",
                keyColumn: "CvijećarnaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hrana",
                keyColumn: "HranaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hrana",
                keyColumn: "HranaID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hrana",
                keyColumn: "HranaID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hrana",
                keyColumn: "HranaID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hrana",
                keyColumn: "HranaID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hrana",
                keyColumn: "HranaID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hrana",
                keyColumn: "HranaID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Cvijećarna",
                keyColumn: "CvijećarnaID",
                keyValue: 1,
                column: "Ime",
                value: "Floral Dreams");

            migrationBuilder.UpdateData(
                table: "Hrana",
                keyColumn: "HranaID",
                keyValue: 1,
                column: "Naziv",
                value: "Roast Beef");

            migrationBuilder.UpdateData(
                table: "Hrana",
                keyColumn: "HranaID",
                keyValue: 2,
                columns: new[] { "CijenaPoOsobi", "Naziv", "TipHrane" },
                values: new object[] { 30.00m, "Chicken Salad", "Predjelo" });

            migrationBuilder.UpdateData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 1,
                column: "ImePartnera",
                value: "Floral Dreams");
        }
    }
}
