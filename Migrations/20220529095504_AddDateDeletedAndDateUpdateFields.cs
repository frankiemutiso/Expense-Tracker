using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Xpense.Migrations
{
    public partial class AddDateDeletedAndDateUpdateFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "date_deleted",
                table: "user_expenses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "date_updated",
                table: "user_expenses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "user_expenses",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_deleted",
                table: "user_expenses");

            migrationBuilder.DropColumn(
                name: "date_updated",
                table: "user_expenses");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "user_expenses");
        }
    }
}
