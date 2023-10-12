using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace openlab_project.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUsersMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GuilD",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "XP",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuilD",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "XP",
                table: "AspNetUsers");
        }
    }
}
