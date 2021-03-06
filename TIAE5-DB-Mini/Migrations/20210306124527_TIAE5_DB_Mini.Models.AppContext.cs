using Microsoft.EntityFrameworkCore.Migrations;

namespace TIAE5_DB_Mini.Migrations
{
    public partial class TIAE5_DB_MiniModelsAppContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    flache = table.Column<double>(type: "float", nullable: false),
                    beteiligteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objekts", x => x.objektId);
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
                    table.ForeignKey(
                        name: "FK_gefaehrdungs_objekts_objektId",
                        column: x => x.objektId,
                        principalTable: "objekts",
                        principalColumn: "objektId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "beteiligtes",
                columns: table => new
                {
                    beteiligteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nachname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gefaehrdungId = table.Column<int>(type: "int", nullable: true),
                    eigentuemerId = table.Column<int>(type: "int", nullable: true),
                    juristischePerson = table.Column<bool>(type: "bit", nullable: true),
                    beteiligtesbeteiligteId = table.Column<int>(type: "int", nullable: true),
                    grundbuchamtId = table.Column<int>(type: "int", nullable: true),
                    amtskennung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    beteiligteId1 = table.Column<int>(type: "int", nullable: true),
                    mitarbeiterId = table.Column<int>(type: "int", nullable: true),
                    badgeNummer = table.Column<int>(type: "int", nullable: true),
                    lohnProMonat = table.Column<float>(type: "real", nullable: true),
                    Mitarbeiter_beteiligteId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beteiligtes", x => x.beteiligteId);
                    table.ForeignKey(
                        name: "FK_beteiligtes_beteiligtes_beteiligteId1",
                        column: x => x.beteiligteId1,
                        principalTable: "beteiligtes",
                        principalColumn: "beteiligteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_beteiligtes_beteiligtes_beteiligtesbeteiligteId",
                        column: x => x.beteiligtesbeteiligteId,
                        principalTable: "beteiligtes",
                        principalColumn: "beteiligteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_beteiligtes_beteiligtes_Mitarbeiter_beteiligteId1",
                        column: x => x.Mitarbeiter_beteiligteId1,
                        principalTable: "beteiligtes",
                        principalColumn: "beteiligteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_beteiligtes_gefaehrdungs_gefaehrdungId",
                        column: x => x.gefaehrdungId,
                        principalTable: "gefaehrdungs",
                        principalColumn: "gefaehrdungId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_beteiligtes_beteiligteId1",
                table: "beteiligtes",
                column: "beteiligteId1");

            migrationBuilder.CreateIndex(
                name: "IX_beteiligtes_beteiligtesbeteiligteId",
                table: "beteiligtes",
                column: "beteiligtesbeteiligteId");

            migrationBuilder.CreateIndex(
                name: "IX_beteiligtes_gefaehrdungId",
                table: "beteiligtes",
                column: "gefaehrdungId");

            migrationBuilder.CreateIndex(
                name: "IX_beteiligtes_Mitarbeiter_beteiligteId1",
                table: "beteiligtes",
                column: "Mitarbeiter_beteiligteId1");

            migrationBuilder.CreateIndex(
                name: "IX_gefaehrdungs_objektId",
                table: "gefaehrdungs",
                column: "objektId");

            migrationBuilder.CreateIndex(
                name: "IX_objekts_beteiligteId",
                table: "objekts",
                column: "beteiligteId");

            migrationBuilder.AddForeignKey(
                name: "FK_objekts_beteiligtes_beteiligteId",
                table: "objekts",
                column: "beteiligteId",
                principalTable: "beteiligtes",
                principalColumn: "beteiligteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beteiligtes_gefaehrdungs_gefaehrdungId",
                table: "beteiligtes");

            migrationBuilder.DropTable(
                name: "gefaehrdungs");

            migrationBuilder.DropTable(
                name: "objekts");

            migrationBuilder.DropTable(
                name: "beteiligtes");
        }
    }
}
