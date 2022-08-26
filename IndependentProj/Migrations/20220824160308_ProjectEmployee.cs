using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndependentProj.Migrations
{
    public partial class ProjectEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employees_EmployeeID",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_EmployeeID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Project");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Projects",
                newName: "PerformerCompanyName");

            migrationBuilder.AddColumn<string>(
                name: "ChoosedEmployee",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerCompanyName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DoneDate",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "ProjectID");

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.EmployeeID, x.ProjectID });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "ChoosedEmployee", "CustomerCompanyName", "DoneDate", "PerformerCompanyName", "Priority", "ProjectName", "StartDate" },
                values: new object[] { 1, "", "FristCustomer", new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "FirstPerformer", 1, "FirstProject", new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectID",
                table: "EmployeeProject",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ChoosedEmployee",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CustomerCompanyName",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DoneDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameColumn(
                name: "PerformerCompanyName",
                table: "Project",
                newName: "CompanyName");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_EmployeeID",
                table: "Project",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employees_EmployeeID",
                table: "Project",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID");
        }
    }
}
