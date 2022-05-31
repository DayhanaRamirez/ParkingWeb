using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingWeb.Migrations
{
    public partial class AddedBoolToParkingCellEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOccupied",
                table: "ParkingCells",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOccupied",
                table: "ParkingCells");
        }
    }
}
