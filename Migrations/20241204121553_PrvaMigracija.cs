using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektProgramskog.Migrations
{
    /// <inheritdoc />
    public partial class PrvaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partneri",
                columns: table => new
                {
                    PartnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePartnera = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BrojTelefona = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Kategorija = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Provizija = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Hrana = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CustomPartneri = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Partneri__39FD63327D5D2D52", x => x.PartnerID);
                });

            migrationBuilder.CreateTable(
                name: "Vjenčanje",
                columns: table => new
                {
                    IDVjenčanja = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateOnly>(type: "date", nullable: false),
                    ImeKontakta = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BrojKontakta = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Template = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Napomena = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vjenčanj__A710B34E885FBD97", x => x.IDVjenčanja);
                });

            migrationBuilder.CreateTable(
                name: "CustomPartneri",
                columns: table => new
                {
                    CustomPartnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Usluga = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CustomPa__08D0F745D59419A7", x => x.CustomPartnerID);
                    table.ForeignKey(
                        name: "FK_CustomPartneri_Partneri",
                        column: x => x.PartnerID,
                        principalTable: "Partneri",
                        principalColumn: "PartnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cvijećarna",
                columns: table => new
                {
                    CvijećarnaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Cijena = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Detalji = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cvijećar__BFA8E7A21956F4E2", x => x.CvijećarnaID);
                    table.ForeignKey(
                        name: "FK__Cvijećarn__Partn__403A8C7D",
                        column: x => x.PartnerID,
                        principalTable: "Partneri",
                        principalColumn: "PartnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Glazbenici",
                columns: table => new
                {
                    GlazbenikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OsnovnaCijena = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CijenaPoSatu = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    SlobodniDatumi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Glazbeni__8ED4C2106614D353", x => x.GlazbenikID);
                    table.ForeignKey(
                        name: "FK__Glazbenic__Partn__4316F928",
                        column: x => x.PartnerID,
                        principalTable: "Partneri",
                        principalColumn: "PartnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hrana",
                columns: table => new
                {
                    HranaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerID = table.Column<int>(type: "int", nullable: false),
                    TipHrane = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CijenaPoOsobi = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Detalji = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hrana__19AD0ACA0CA31B25", x => x.HranaID);
                    table.ForeignKey(
                        name: "FK__Hrana__PartnerID__4AB81AF0",
                        column: x => x.PartnerID,
                        principalTable: "Partneri",
                        principalColumn: "PartnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    LokacijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CijenaPoDanu = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Catering = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lokacija__49DE2C2A95ACE938", x => x.LokacijaID);
                    table.ForeignKey(
                        name: "FK__Lokacija__Partne__5070F446",
                        column: x => x.PartnerID,
                        principalTable: "Partneri",
                        principalColumn: "PartnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gosti",
                columns: table => new
                {
                    GostiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVjenčanja = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BrojStola = table.Column<int>(type: "int", nullable: true),
                    StatusGosta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "Potvrdili dolazak")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Gosti__6A3535C435292757", x => x.GostiID);
                    table.ForeignKey(
                        name: "FK__Gosti__IDVjenčan__00200768",
                        column: x => x.IDVjenčanja,
                        principalTable: "Vjenčanje",
                        principalColumn: "IDVjenčanja",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Izvještaj",
                columns: table => new
                {
                    IzvještajID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVjenčanja = table.Column<int>(type: "int", nullable: false),
                    TipIzvještaja = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Sadržaj = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Izvješta__DA1089BCFF48F48E", x => x.IzvještajID);
                    table.ForeignKey(
                        name: "FK__Izvještaj__IDVje__7C4F7684",
                        column: x => x.IDVjenčanja,
                        principalTable: "Vjenčanje",
                        principalColumn: "IDVjenčanja",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ponude",
                columns: table => new
                {
                    PonudaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerID = table.Column<int>(type: "int", nullable: false),
                    IDVjenčanja = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Cijena = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Detalji = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ponude__5AF121B10DD24B45", x => x.PonudaID);
                    table.ForeignKey(
                        name: "FK__Ponude__IDVjenča__787EE5A0",
                        column: x => x.IDVjenčanja,
                        principalTable: "Vjenčanje",
                        principalColumn: "IDVjenčanja",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Ponude__PartnerI__797309D9",
                        column: x => x.PartnerID,
                        principalTable: "Partneri",
                        principalColumn: "PartnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    PlaylistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlazbenikID = table.Column<int>(type: "int", nullable: false),
                    ListPjesama = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Playlist__B30167809234BB8F", x => x.PlaylistID);
                    table.ForeignKey(
                        name: "FK__Playlists__Glazb__5629CD9C",
                        column: x => x.GlazbenikID,
                        principalTable: "Glazbenici",
                        principalColumn: "GlazbenikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meni",
                columns: table => new
                {
                    MeniID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HranaID = table.Column<int>(type: "int", nullable: false),
                    VrstaHrane = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BrojSljedova = table.Column<int>(type: "int", nullable: true),
                    CustomObrok = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Meni__EEA512D50B225059", x => x.MeniID);
                    table.ForeignKey(
                        name: "FK__Meni__HranaID__534D60F1",
                        column: x => x.HranaID,
                        principalTable: "Hrana",
                        principalColumn: "HranaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Partneri",
                columns: new[] { "PartnerID", "BrojTelefona", "Email", "ImePartnera", "Kategorija", "Provizija" },
                values: new object[,]
                {
                    { 1, "123-456-789", "info@floraldreams.com", "Floral Dreams", "Cvjećarna", 0.10m },
                    { 2, "987-654-321", "contact@guitarmasters.com", "Guitar Masters", "Glazba", 0.15m }
                });

            migrationBuilder.InsertData(
                table: "Vjenčanje",
                columns: new[] { "IDVjenčanja", "BrojKontakta", "Datum", "ImeKontakta", "Napomena", "Template" },
                values: new object[] { 1, "123-123-123", new DateOnly(1, 1, 1), "Anna and Mark", "Wedding ceremony with special decorations", "Luxury" });

            migrationBuilder.InsertData(
                table: "Cvijećarna",
                columns: new[] { "CvijećarnaID", "Cijena", "Detalji", "Ime", "PartnerID" },
                values: new object[] { 1, 500m, null, "Floral Dreams", 1 });

            migrationBuilder.InsertData(
                table: "Glazbenici",
                columns: new[] { "GlazbenikID", "CijenaPoSatu", "Ime", "OsnovnaCijena", "PartnerID", "SlobodniDatumi" },
                values: new object[] { 1, 200m, "The Melody Band", 1000m, 2, null });

            migrationBuilder.InsertData(
                table: "Gosti",
                columns: new[] { "GostiID", "BrojStola", "IDVjenčanja", "Ime", "StatusGosta" },
                values: new object[,]
                {
                    { 1, null, 1, "John Doe", "Potvrdili dolazak" },
                    { 2, null, 1, "Jane Smith", "Potvrdili dolazak" }
                });

            migrationBuilder.InsertData(
                table: "Hrana",
                columns: new[] { "HranaID", "CijenaPoOsobi", "Detalji", "Naziv", "PartnerID", "TipHrane" },
                values: new object[,]
                {
                    { 1, 50.00m, null, "Roast Beef", 1, "Glavno jelo" },
                    { 2, 30.00m, null, "Chicken Salad", 1, "Predjelo" }
                });

            migrationBuilder.InsertData(
                table: "Izvještaj",
                columns: new[] { "IzvještajID", "IDVjenčanja", "Sadržaj", "TipIzvještaja" },
                values: new object[] { 1, 1, "Izvještaj o statusu priprema za vjenčanje.", "Planiranje" });

            migrationBuilder.InsertData(
                table: "Lokacija",
                columns: new[] { "LokacijaID", "Catering", "CijenaPoDanu", "Ime", "PartnerID" },
                values: new object[] { 1, null, 1500.00m, "Beach Resort", 1 });

            migrationBuilder.InsertData(
                table: "Ponude",
                columns: new[] { "PonudaID", "Cijena", "Detalji", "IDVjenčanja", "Ime", "PartnerID" },
                values: new object[,]
                {
                    { 1, 5000.00m, "Complete wedding package including venue, catering, and entertainment.", 1, "Luxury Wedding Package", 1 },
                    { 2, 3000.00m, "Wedding package including venue, catering, and entertainment.", 1, "Medium Wedding Package", 1 }
                });

            migrationBuilder.InsertData(
                table: "Meni",
                columns: new[] { "MeniID", "BrojSljedova", "Cijena", "CustomObrok", "HranaID", "VrstaHrane" },
                values: new object[,]
                {
                    { 1, null, 50.00m, null, 1, "Glavno jelo" },
                    { 2, null, 30.00m, null, 2, "Predjelo" }
                });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "PlaylistID", "GlazbenikID", "ListPjesama" },
                values: new object[] { 1, 1, "Song 1, Song 2, Song 3" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomPartneri_PartnerID",
                table: "CustomPartneri",
                column: "PartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Cvijećarna_PartnerID",
                table: "Cvijećarna",
                column: "PartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Glazbenici_PartnerID",
                table: "Glazbenici",
                column: "PartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Gosti_IDVjenčanja",
                table: "Gosti",
                column: "IDVjenčanja");

            migrationBuilder.CreateIndex(
                name: "IX_Hrana_PartnerID",
                table: "Hrana",
                column: "PartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Izvještaj_IDVjenčanja",
                table: "Izvještaj",
                column: "IDVjenčanja");

            migrationBuilder.CreateIndex(
                name: "IX_Lokacija_PartnerID",
                table: "Lokacija",
                column: "PartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Meni_HranaID",
                table: "Meni",
                column: "HranaID");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_GlazbenikID",
                table: "Playlists",
                column: "GlazbenikID");

            migrationBuilder.CreateIndex(
                name: "IX_Ponude_IDVjenčanja",
                table: "Ponude",
                column: "IDVjenčanja");

            migrationBuilder.CreateIndex(
                name: "IX_Ponude_PartnerID",
                table: "Ponude",
                column: "PartnerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomPartneri");

            migrationBuilder.DropTable(
                name: "Cvijećarna");

            migrationBuilder.DropTable(
                name: "Gosti");

            migrationBuilder.DropTable(
                name: "Izvještaj");

            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "Meni");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Ponude");

            migrationBuilder.DropTable(
                name: "Hrana");

            migrationBuilder.DropTable(
                name: "Glazbenici");

            migrationBuilder.DropTable(
                name: "Vjenčanje");

            migrationBuilder.DropTable(
                name: "Partneri");
        }
    }
}
