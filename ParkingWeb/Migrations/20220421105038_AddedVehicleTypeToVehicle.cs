using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingWeb.Migrations
{
    public partial class AddedVehicleTypeToVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Vehicles");
        }
    }
}
