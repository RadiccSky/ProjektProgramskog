using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class Partner3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Glazbenici",
                keyColumn: "GlazbenikID",
                keyValue: 1,
                column: "Ime",
                value: "Guitar Masters");

            migrationBuilder.InsertData(
                table: "Partneri",
                columns: new[] { "PartnerID", "BrojTelefona", "Email", "ImePartnera", "Kategorija", "Provizija" },
                values: new object[] { 3, "987-654-321", "contact@guitarmasters.com", "Ajkula", "Glazba", 0.15m });

            migrationBuilder.InsertData(
                table: "Glazbenici",
                columns: new[] { "GlazbenikID", "CijenaPoSatu", "Ime", "OsnovnaCijena", "PartnerID", "SlobodniDatumi" },
                values: new object[] { 2, 200m, "Ajkula", 1000m, 3, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Glazbenici",
                keyColumn: "GlazbenikID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Partneri",
                keyColumn: "PartnerID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Glazbenici",
                keyColumn: "GlazbenikID",
                keyValue: 1,
                column: "Ime",
                value: "The Melody Band");
        }
    }
}
