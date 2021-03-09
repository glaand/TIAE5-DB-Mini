using Microsoft.EntityFrameworkCore.Migrations;

namespace TIAE5_DB_Mini.Migrations
{
    public partial class TIAE5_DB_MiniModelsAppContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "beteiligtes",
                columns: table => new
                {
                    beteiligteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nachname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beteiligtes", x => x.beteiligteId);
                });

            migrationBuilder.CreateTable(
                name: "objekts",
                columns: table => new
                {
                    objektId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    laengengrad = table.Column<double>(type: "float", nullable: false),
                    breitengrad = table.Column<double>(type: "float", nullable: false),
                    laenge = table.Column<double>(type: "float", nullable: false),
                    breite = table.Column<double>(type: "float", nullable: false),
                    flache = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objekts", x => x.objektId);
                    table.CheckConstraint("CK_Objekt_Laengengrad", "[laengengrad] >= -180 AND [laengengrad] <= 180");
                    table.CheckConstraint("CK_Objekt_Breitengrad", "[breitengrad] >= -90 AND [breitengrad] <= 90");
                    table.CheckConstraint("CK_Objekt_Laenge", "[laenge] > 0");
                    table.CheckConstraint("CK_Objekt_Breite", "[breite] > 0");
                    table.CheckConstraint("CK_Objekt_Flache", "[flache] > 0");
                });

            migrationBuilder.CreateTable(
                name: "eigentuemer",
                columns: table => new
                {
                    beteiligteId = table.Column<int>(type: "int", nullable: false),
                    beteiligtesbeteiligteId = table.Column<int>(type: "int", nullable: true),
                    juristischePerson = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eigentuemer", x => x.beteiligteId);
                    table.ForeignKey(
                        name: "FK_eigentuemer_beteiligtes_beteiligteId",
                        column: x => x.beteiligteId,
                        principalTable: "beteiligtes",
                        principalColumn: "beteiligteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_eigentuemer_beteiligtes_beteiligtesbeteiligteId",
                        column: x => x.beteiligtesbeteiligteId,
                        principalTable: "beteiligtes",
                        principalColumn: "beteiligteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "grundbuchamt",
                columns: table => new
                {
                    beteiligteId = table.Column<int>(type: "int", nullable: false),
                    beteiligteId1 = table.Column<int>(type: "int", nullable: true),
                    amtskennung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grundbuchamt", x => x.beteiligteId);
                    table.ForeignKey(
                        name: "FK_grundbuchamt_beteiligtes_beteiligteId",
                        column: x => x.beteiligteId,
                        principalTable: "beteiligtes",
                        principalColumn: "beteiligteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_grundbuchamt_beteiligtes_beteiligteId1",
                        column: x => x.beteiligteId1,
                        principalTable: "beteiligtes",
                        principalColumn: "beteiligteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mitarbeiter",
                columns: table => new
                {
                    beteiligteId = table.Column<int>(type: "int", nullable: false),
                    beteiligteId1 = table.Column<int>(type: "int", nullable: true),
                    badgeNummer = table.Column<int>(type: "int", nullable: false),
                    lohnProMonat = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mitarbeiter", x => x.beteiligteId);
                    table.ForeignKey(
                        name: "FK_mitarbeiter_beteiligtes_beteiligteId",
                        column: x => x.beteiligteId,
                        principalTable: "beteiligtes",
                        principalColumn: "beteiligteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mitarbeiter_beteiligtes_beteiligteId1",
                        column: x => x.beteiligteId1,
                        principalTable: "beteiligtes",
                        principalColumn: "beteiligteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BeteiligteObjekt",
                columns: table => new
                {
                    beteiligtesbeteiligteId = table.Column<int>(type: "int", nullable: false),
                    objektsobjektId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeteiligteObjekt", x => new { x.beteiligtesbeteiligteId, x.objektsobjektId });
                    table.ForeignKey(
                        name: "FK_BeteiligteObjekt_beteiligtes_beteiligtesbeteiligteId",
                        column: x => x.beteiligtesbeteiligteId,
                        principalTable: "beteiligtes",
                        principalColumn: "beteiligteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeteiligteObjekt_objekts_objektsobjektId",
                        column: x => x.objektsobjektId,
                        principalTable: "objekts",
                        principalColumn: "objektId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gefaehrdungs",
                columns: table => new
                {
                    gefaehrdungId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gefaehrdungsstufe = table.Column<int>(type: "int", nullable: false),
                    beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hatVerfuegung = table.Column<bool>(type: "bit", nullable: false),
                    objektId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gefaehrdungs", x => x.gefaehrdungId);
                    table.CheckConstraint("CK_Gefaehrdung_Stufe", "[gefaehrdungsstufe] > 0 AND [gefaehrdungsstufe] < 10");
                    table.ForeignKey(
                        name: "FK_gefaehrdungs_objekts_objektId",
                        column: x => x.objektId,
                        principalTable: "objekts",
                        principalColumn: "objektId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "beteiligtes",
                columns: new[] { "beteiligteId", "nachname", "vorname" },
                values: new object[,]
                {
                    { 1, "Gehring", "Sven" },
                    { 3, "Müller", "Lukas" },
                    { 2, "Glatzl", "André" }
                });

            migrationBuilder.InsertData(
                table: "objekts",
                columns: new[] { "objektId", "breite", "breitengrad", "flache", "laenge", "laengengrad" },
                values: new object[,]
                {
                    { 1, 80.0, 90.0, 120.0, 100.0, 90.0 },
                    { 2, 90.0, 80.0, 130.0, 110.0, 80.0 },
                    { 3, 100.0, 70.0, 140.0, 120.0, 70.0 }
                });

            migrationBuilder.InsertData(
                table: "eigentuemer",
                columns: new[] { "beteiligteId", "beteiligtesbeteiligteId", "juristischePerson" },
                values: new object[] { 1, null, true });

            migrationBuilder.InsertData(
                table: "gefaehrdungs",
                columns: new[] { "gefaehrdungId", "beschreibung", "gefaehrdungsstufe", "hatVerfuegung", "objektId" },
                values: new object[,]
                {
                    { 1, "bla", 1, true, 1 },
                    { 2, "bla bla", 2, false, 2 },
                    { 3, "bla bla bla", 3, true, 3 }
                });

            migrationBuilder.InsertData(
                table: "grundbuchamt",
                columns: new[] { "beteiligteId", "amtskennung", "beteiligteId1" },
                values: new object[] { 3, "ZH Hochbau", null });

            migrationBuilder.InsertData(
                table: "mitarbeiter",
                columns: new[] { "beteiligteId", "badgeNummer", "beteiligteId1", "lohnProMonat" },
                values: new object[] { 2, 1000, null, 5000f });

            migrationBuilder.CreateIndex(
                name: "IX_BeteiligteObjekt_objektsobjektId",
                table: "BeteiligteObjekt",
                column: "objektsobjektId");

            migrationBuilder.CreateIndex(
                name: "IX_eigentuemer_beteiligtesbeteiligteId",
                table: "eigentuemer",
                column: "beteiligtesbeteiligteId");

            migrationBuilder.CreateIndex(
                name: "IX_gefaehrdungs_objektId",
                table: "gefaehrdungs",
                column: "objektId");

            migrationBuilder.CreateIndex(
                name: "IX_grundbuchamt_beteiligteId1",
                table: "grundbuchamt",
                column: "beteiligteId1");

            migrationBuilder.CreateIndex(
                name: "IX_mitarbeiter_beteiligteId1",
                table: "mitarbeiter",
                column: "beteiligteId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeteiligteObjekt");

            migrationBuilder.DropTable(
                name: "eigentuemer");

            migrationBuilder.DropTable(
                name: "gefaehrdungs");

            migrationBuilder.DropTable(
                name: "grundbuchamt");

            migrationBuilder.DropTable(
                name: "mitarbeiter");

            migrationBuilder.DropTable(
                name: "objekts");

            migrationBuilder.DropTable(
                name: "beteiligtes");
        }
    }
}
