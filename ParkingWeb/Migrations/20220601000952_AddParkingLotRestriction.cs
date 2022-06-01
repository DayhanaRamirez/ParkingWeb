using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingWeb.Migrations
{
    public partial class AddParkingLotRestriction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingLotRestrictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingLotId = table.Column<int>(type: "int", nullable: true),
                    RestrictionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLotRestrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingLotRestrictions_ParkingLots_ParkingLotId",
                        column: x => x.ParkingLotId,
                        principalTable: "ParkingLots",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParkingLotRestrictions_Restrictions_RestrictionId",
                        column: x => x.RestrictionId,
                        principalTable: "Restrictions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLotRestrictions_ParkingLotId_RestrictionId",
                table: "ParkingLotRestrictions",
                columns: new[] { "ParkingLotId", "RestrictionId" },
                unique: true,
                filter: "[ParkingLotId] IS NOT NULL AND [RestrictionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLotRestrictions_RestrictionId",
                table: "ParkingLotRestrictions",
                column: "RestrictionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingLotRestrictions");
        }
    }
}
