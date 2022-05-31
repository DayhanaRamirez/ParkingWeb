using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingWeb.Migrations
{
    public partial class AddedIndexToCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Campuses_Name",
                table: "Campuses",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Campuses_Name",
                table: "Campuses");
        }
    }
}
