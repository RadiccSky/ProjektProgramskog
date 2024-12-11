using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class AddTemplateFieldsToPonude : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "JeUnaprijedDefiniran",
                table: "Ponude",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JsonPodaci",
                table: "Ponude",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Ponude",
                keyColumn: "PonudaID",
                keyValue: 1,
                columns: new[] { "JeUnaprijedDefiniran", "JsonPodaci" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Ponude",
                keyColumn: "PonudaID",
                keyValue: 2,
                columns: new[] { "JeUnaprijedDefiniran", "JsonPodaci" },
                values: new object[] { false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JeUnaprijedDefiniran",
                table: "Ponude");

            migrationBuilder.DropColumn(
                name: "JsonPodaci",
                table: "Ponude");
        }
    }
}
