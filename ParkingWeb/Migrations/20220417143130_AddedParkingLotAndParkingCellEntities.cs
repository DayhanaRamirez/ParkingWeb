using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingWeb.Migrations
{
    public partial class AddedParkingLotAndParkingCellEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingLots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CampusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingLots_Campuses_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingCells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ParkingLotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingCells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingCells_ParkingLots_ParkingLotId",
                        column: x => x.ParkingLotId,
                        principalTable: "ParkingLots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingCells_Name_ParkingLotId",
                table: "ParkingCells",
                columns: new[] { "Name", "ParkingLotId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingCells_ParkingLotId",
                table: "ParkingCells",
                column: "ParkingLotId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_CampusId",
                table: "ParkingLots",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_Name_CampusId",
                table: "ParkingLots",
                columns: new[] { "Name", "CampusId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingCells");

            migrationBuilder.DropTable(
                name: "ParkingLots");
        }
    }
}
