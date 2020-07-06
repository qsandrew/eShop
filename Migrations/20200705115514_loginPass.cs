using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.Migrations
{
    public partial class loginPass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Employees",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employees",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Login",
                table: "Employees",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Login",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employees");
        }
    }
}
