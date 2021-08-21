using Microsoft.EntityFrameworkCore.Migrations;

namespace Taskly.Data.Migrations
{
    public partial class ChangeColorToHex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorArgb",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ColorArgb",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ColorArgb",
                table: "Labels");

            migrationBuilder.AddColumn<string>(
                name: "ColorHex",
                table: "Projects",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorHex",
                table: "Notes",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorHex",
                table: "Labels",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorHex",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ColorHex",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ColorHex",
                table: "Labels");

            migrationBuilder.AddColumn<int>(
                name: "ColorArgb",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorArgb",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorArgb",
                table: "Labels",
                type: "int",
                nullable: true);
        }
    }
}
