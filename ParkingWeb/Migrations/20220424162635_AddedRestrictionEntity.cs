using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingWeb.Migrations
{
    public partial class AddedRestrictionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingCells_ParkingLots_ParkingLotId",
                table: "ParkingCells");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_Campuses_CampusId",
                table: "ParkingLots");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_ParkingLots_Name_CampusId",
                table: "ParkingLots");

            migrationBuilder.DropIndex(
                name: "IX_ParkingCells_Name_ParkingLotId",
                table: "ParkingCells");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleTypeId",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "CampusId",
                table: "ParkingLots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "ParkingLots",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParkingLotId",
                table: "ParkingCells",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "ParkingCells",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Restrictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Car1 = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Car2 = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Motorcycle1 = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Motorcycle2 = table.Column<int>(type: "int", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restrictions", x => x.Id);
                });

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
                name: "IX_ParkingLots_Name_CampusId",
                table: "ParkingLots",
                columns: new[] { "Name", "CampusId" },
                unique: true,
                filter: "[CampusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_VehicleTypeId",
                table: "ParkingLots",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingCells_Name_ParkingLotId",
                table: "ParkingCells",
                columns: new[] { "Name", "ParkingLotId" },
                unique: true,
                filter: "[ParkingLotId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingCells_VehicleTypeId",
                table: "ParkingCells",
                column: "VehicleTypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Restrictions_Day",
                table: "Restrictions",
                column: "Day",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingCells_ParkingLots_ParkingLotId",
                table: "ParkingCells",
                column: "ParkingLotId",
                principalTable: "ParkingLots",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingCells_VehicleTypes_VehicleTypeId",
                table: "ParkingCells",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLots_Campuses_CampusId",
                table: "ParkingLots",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLots_VehicleTypes_VehicleTypeId",
                table: "ParkingLots",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserId",
                table: "Vehicles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingCells_ParkingLots_ParkingLotId",
                table: "ParkingCells");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingCells_VehicleTypes_VehicleTypeId",
                table: "ParkingCells");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_Campuses_CampusId",
                table: "ParkingLots");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_VehicleTypes_VehicleTypeId",
                table: "ParkingLots");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "ParkingCellRestrictions");

            migrationBuilder.DropTable(
                name: "Restrictions");

            migrationBuilder.DropIndex(
                name: "IX_ParkingLots_Name_CampusId",
                table: "ParkingLots");

            migrationBuilder.DropIndex(
                name: "IX_ParkingLots_VehicleTypeId",
                table: "ParkingLots");

            migrationBuilder.DropIndex(
                name: "IX_ParkingCells_Name_ParkingLotId",
                table: "ParkingCells");

            migrationBuilder.DropIndex(
                name: "IX_ParkingCells_VehicleTypeId",
                table: "ParkingCells");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "ParkingLots");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "ParkingCells");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleTypeId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CampusId",
                table: "ParkingLots",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParkingLotId",
                table: "ParkingCells",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_Name_CampusId",
                table: "ParkingLots",
                columns: new[] { "Name", "CampusId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingCells_Name_ParkingLotId",
                table: "ParkingCells",
                columns: new[] { "Name", "ParkingLotId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingCells_ParkingLots_ParkingLotId",
                table: "ParkingCells",
                column: "ParkingLotId",
                principalTable: "ParkingLots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLots_Campuses_CampusId",
                table: "ParkingLots",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserId",
                table: "Vehicles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
