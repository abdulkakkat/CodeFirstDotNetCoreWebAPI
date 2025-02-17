using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Api.Migrations
{
    public partial class forienKeyudatedmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manager",
                table: "Employee",
                newName: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ManagerID",
                table: "Employee",
                column: "ManagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Manager_ManagerID",
                table: "Employee",
                column: "ManagerID",
                principalTable: "Manager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Manager_ManagerID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ManagerID",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "ManagerID",
                table: "Employee",
                newName: "Manager");
        }
    }
}
