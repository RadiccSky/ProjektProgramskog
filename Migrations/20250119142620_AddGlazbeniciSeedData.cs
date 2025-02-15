using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class AddGlazbeniciSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Glazbenici",
                keyColumn: "GlazbenikID",
                keyValue: 1,
                columns: new[] { "PartnerID", "SlobodniDatumi" },
                values: new object[] { 1, "2024-01-01,2024-01-02" });

            migrationBuilder.UpdateData(
                table: "Glazbenici",
                keyColumn: "GlazbenikID",
                keyValue: 2,
                columns: new[] { "CijenaPoSatu", "OsnovnaCijena", "PartnerID", "SlobodniDatumi" },
                values: new object[] { 250m, 1500m, 2, "2024-01-03,2024-01-04" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Glazbenici",
                keyColumn: "GlazbenikID",
                keyValue: 1,
                columns: new[] { "PartnerID", "SlobodniDatumi" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Glazbenici",
                keyColumn: "GlazbenikID",
                keyValue: 2,
                columns: new[] { "CijenaPoSatu", "OsnovnaCijena", "PartnerID", "SlobodniDatumi" },
                values: new object[] { 200m, 1000m, 3, null });
        }
    }
}
