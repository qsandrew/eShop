using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.Migrations
{
    public partial class EmpLinkEnterprise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnterpriseId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EnterpriseId",
                table: "Employees",
                column: "EnterpriseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Enterprises_EnterpriseId",
                table: "Employees",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Enterprises_EnterpriseId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EnterpriseId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "Employees");
        }
    }
}
