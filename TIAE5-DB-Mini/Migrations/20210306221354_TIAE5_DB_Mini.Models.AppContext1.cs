using Microsoft.EntityFrameworkCore.Migrations;

namespace TIAE5_DB_Mini.Migrations
{
    public partial class TIAE5_DB_MiniModelsAppContext1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BeteiligteObjekt",
                columns: new[] { "beteiligtesbeteiligteId", "objektsobjektId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
