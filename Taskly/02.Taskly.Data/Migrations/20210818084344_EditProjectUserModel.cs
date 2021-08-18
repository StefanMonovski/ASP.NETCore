using Microsoft.EntityFrameworkCore.Migrations;

namespace Taskly.Data.Migrations
{
    public partial class EditProjectUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Projects");

            migrationBuilder.AddColumn<bool>(
                name: "IsProjectFavorite",
                table: "ProjectsUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProjectFavorite",
                table: "ProjectsUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
