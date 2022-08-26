using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndependentProj.Migrations
{
    public partial class EmployeeProject_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChoosedEmployee",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ChoosedProject",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "ChoosedEmployeeID",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChoosedProjectID",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChoosedEmployeeID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ChoosedProjectID",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "ChoosedEmployee",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChoosedProject",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                column: "ChoosedProject",
                value: "");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 1,
                column: "ChoosedEmployee",
                value: "");
        }
    }
}
