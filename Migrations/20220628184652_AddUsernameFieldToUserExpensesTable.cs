using Microsoft.EntityFrameworkCore.Migrations;

namespace Xpense.Migrations
{
    public partial class AddUsernameFieldToUserExpensesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "user_expenses",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "username",
                table: "user_expenses");
        }
    }
}
