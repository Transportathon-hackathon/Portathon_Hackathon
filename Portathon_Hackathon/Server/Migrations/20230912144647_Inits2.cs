using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portathon_Hackathon.Server.Migrations
{
    public partial class Inits2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserId",
                table: "Companies",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UserId",
                table: "Companies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UserId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_UserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Companies");
        }
    }
}
