using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gosti",
                keyColumn: "GostiID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "BrojStola",
                table: "Gosti");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Gosti");

            migrationBuilder.DropColumn(
                name: "StatusGosta",
                table: "Gosti");

            migrationBuilder.AddColumn<int>(
                name: "BrojGostiju",
                table: "Gosti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Gosti",
                keyColumn: "GostiID",
                keyValue: 1,
                column: "BrojGostiju",
                value: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojGostiju",
                table: "Gosti");

            migrationBuilder.AddColumn<int>(
                name: "BrojStola",
                table: "Gosti",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Gosti",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusGosta",
                table: "Gosti",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "Potvrdili dolazak");

            migrationBuilder.UpdateData(
                table: "Gosti",
                keyColumn: "GostiID",
                keyValue: 1,
                columns: new[] { "BrojStola", "Ime", "StatusGosta" },
                values: new object[] { null, "John Doe", "Potvrdili dolazak" });

            migrationBuilder.InsertData(
                table: "Gosti",
                columns: new[] { "GostiID", "BrojStola", "IDVjenčanja", "Ime", "StatusGosta" },
                values: new object[] { 2, null, 1, "Jane Smith", "Potvrdili dolazak" });
        }
    }
}
