using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingWeb.Migrations
{
    public partial class ChangedParkingCell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "ParkingCells",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingCells_VehicleId",
                table: "ParkingCells",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingCells_Vehicles_VehicleId",
                table: "ParkingCells",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingCells_Vehicles_VehicleId",
                table: "ParkingCells");

            migrationBuilder.DropIndex(
                name: "IX_ParkingCells_VehicleId",
                table: "ParkingCells");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "ParkingCells");
        }
    }
}
