using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingWeb.Migrations
{
    public partial class ChangedRestrictionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Motorcycle2",
                table: "Restrictions",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Motorcycle1",
                table: "Restrictions",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Car2",
                table: "Restrictions",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Car1",
                table: "Restrictions",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Motorcycle2",
                table: "Restrictions",
                type: "int",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Motorcycle1",
                table: "Restrictions",
                type: "int",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Car2",
                table: "Restrictions",
                type: "int",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Car1",
                table: "Restrictions",
                type: "int",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);
        }
    }
}
