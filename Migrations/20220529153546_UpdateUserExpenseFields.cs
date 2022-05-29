using Microsoft.EntityFrameworkCore.Migrations;

namespace Xpense.Migrations
{
    public partial class UpdateUserExpenseFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "expense_name",
                table: "user_expenses",
                newName: "expense_description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "expense_description",
                table: "user_expenses",
                newName: "expense_name");
        }
    }
}
