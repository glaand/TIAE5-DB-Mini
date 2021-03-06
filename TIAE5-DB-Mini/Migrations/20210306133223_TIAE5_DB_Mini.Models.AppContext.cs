﻿using Microsoft.EntityFrameworkCore.Migrations;

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
                    vorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nachname = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "eigentuemer",
                columns: table => new
                {
                    beteiligteId = table.Column<int>(type: "int", nullable: false),
                    eigentuemerId = table.Column<int>(type: "int", nullable: false),
                    juristischePerson = table.Column<bool>(type: "bit", nullable: false),
                    beteiligtesbeteiligteId = table.Column<int>(type: "int", nullable: true)
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
                    grundbuchamtId = table.Column<int>(type: "int", nullable: false),
                    amtskennung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    beteiligteId1 = table.Column<int>(type: "int", nullable: true)
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
                    mitarbeiterId = table.Column<int>(type: "int", nullable: false),
                    badgeNummer = table.Column<int>(type: "int", nullable: false),
                    lohnProMonat = table.Column<float>(type: "real", nullable: false),
                    beteiligteId1 = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_gefaehrdungs_objekts_objektId",
                        column: x => x.objektId,
                        principalTable: "objekts",
                        principalColumn: "objektId",
                        onDelete: ReferentialAction.Restrict);
                });

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