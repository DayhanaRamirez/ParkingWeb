using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingWeb.Migrations
{
    public partial class ChangedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingCellRestrictions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingCellRestrictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingCellId = table.Column<int>(type: "int", nullable: true),
                    RestrictionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingCellRestrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingCellRestrictions_ParkingCells_ParkingCellId",
                        column: x => x.ParkingCellId,
                        principalTable: "ParkingCells",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParkingCellRestrictions_Restrictions_RestrictionId",
                        column: x => x.RestrictionId,
                        principalTable: "Restrictions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingCellRestrictions_ParkingCellId_RestrictionId",
                table: "ParkingCellRestrictions",
                columns: new[] { "ParkingCellId", "RestrictionId" },
                unique: true,
                filter: "[ParkingCellId] IS NOT NULL AND [RestrictionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingCellRestrictions_RestrictionId",
                table: "ParkingCellRestrictions",
                column: "RestrictionId");
        }
    }
}
