using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace openlab_project.Data.Migrations
{
    /// <inheritdoc />
    public partial class Guild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GuildInfo_GuildId",
                table: "AspNetUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_GuildInfo_TempId",
                table: "GuildInfo");

            migrationBuilder.RenameColumn(
                name: "GuildMembers",
                table: "Guilds",
                newName: "MembersCount");

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "GuildInfo",
                newName: "GuildMaxMembers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Guilds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuildInformation",
                table: "Guilds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuildMaxMembers",
                table: "Guilds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GuildInfo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GuildInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuildName",
                table: "GuildInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuildInfo",
                table: "GuildInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_GuildInfo_GuildId",
                table: "AspNetUsers",
                column: "GuildId",
                principalTable: "GuildInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GuildInfo_GuildId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuildInfo",
                table: "GuildInfo");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Guilds");

            migrationBuilder.DropColumn(
                name: "GuildInformation",
                table: "Guilds");

            migrationBuilder.DropColumn(
                name: "GuildMaxMembers",
                table: "Guilds");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GuildInfo");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "GuildInfo");

            migrationBuilder.DropColumn(
                name: "GuildName",
                table: "GuildInfo");

            migrationBuilder.RenameColumn(
                name: "MembersCount",
                table: "Guilds",
                newName: "GuildMembers");

            migrationBuilder.RenameColumn(
                name: "GuildMaxMembers",
                table: "GuildInfo",
                newName: "TempId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_GuildInfo_TempId",
                table: "GuildInfo",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_GuildInfo_GuildId",
                table: "AspNetUsers",
                column: "GuildId",
                principalTable: "GuildInfo",
                principalColumn: "TempId");
        }
    }
}
