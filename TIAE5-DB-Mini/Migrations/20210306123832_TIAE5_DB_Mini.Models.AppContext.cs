using Microsoft.EntityFrameworkCore.Migrations;

namespace TIAE5_DB_Mini.Migrations
{
    public partial class TIAE5_DB_MiniModelsAppContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eigentuemers",
                columns: table => new
                {
                    eigentuemerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    juristischePerson = table.Column<bool>(type: "bit", nullable: false),
                    beteiligtesbeteiligteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eigentuemers", x => x.eigentuemerId);
                });

            migrationBuilder.CreateTable(
                name: "grundbuchamts",
                columns: table => new
                {
                    grundbuchamtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amtskennung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    beteiligteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grundbuchamts", x => x.grundbuchamtId);
                });

            migrationBuilder.CreateTable(
                name: "mitarbeiters",
                columns: table => new
                {
                    mitarbeiterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    badgeNummer = table.Column<int>(type: "int", nullable: false),
                    lohnProMonat = table.Column<float>(type: "real", nullable: false),
                    beteiligteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mitarbeiters", x => x.mitarbeiterId);
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
                    gefaehrdungId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beteiligtes", x => x.beteiligteId);
                    table.ForeignKey(
                        name: "FK_beteiligtes_gefaehrdungs_gefaehrdungId",
                        column: x => x.gefaehrdungId,
                        principalTable: "gefaehrdungs",
                        principalColumn: "gefaehrdungId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_beteiligtes_gefaehrdungId",
                table: "beteiligtes",
                column: "gefaehrdungId");

            migrationBuilder.CreateIndex(
                name: "IX_eigentuemers_beteiligtesbeteiligteId",
                table: "eigentuemers",
                column: "beteiligtesbeteiligteId");

            migrationBuilder.CreateIndex(
                name: "IX_gefaehrdungs_objektId",
                table: "gefaehrdungs",
                column: "objektId");

            migrationBuilder.CreateIndex(
                name: "IX_grundbuchamts_beteiligteId",
                table: "grundbuchamts",
                column: "beteiligteId");

            migrationBuilder.CreateIndex(
                name: "IX_mitarbeiters_beteiligteId",
                table: "mitarbeiters",
                column: "beteiligteId");

            migrationBuilder.CreateIndex(
                name: "IX_objekts_beteiligteId",
                table: "objekts",
                column: "beteiligteId");

            migrationBuilder.AddForeignKey(
                name: "FK_eigentuemers_beteiligtes_beteiligtesbeteiligteId",
                table: "eigentuemers",
                column: "beteiligtesbeteiligteId",
                principalTable: "beteiligtes",
                principalColumn: "beteiligteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_grundbuchamts_beteiligtes_beteiligteId",
                table: "grundbuchamts",
                column: "beteiligteId",
                principalTable: "beteiligtes",
                principalColumn: "beteiligteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mitarbeiters_beteiligtes_beteiligteId",
                table: "mitarbeiters",
                column: "beteiligteId",
                principalTable: "beteiligtes",
                principalColumn: "beteiligteId",
                onDelete: ReferentialAction.Restrict);

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
                name: "eigentuemers");

            migrationBuilder.DropTable(
                name: "grundbuchamts");

            migrationBuilder.DropTable(
                name: "mitarbeiters");

            migrationBuilder.DropTable(
                name: "gefaehrdungs");

            migrationBuilder.DropTable(
                name: "objekts");

            migrationBuilder.DropTable(
                name: "beteiligtes");
        }
    }
}
