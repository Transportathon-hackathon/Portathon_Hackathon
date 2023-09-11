using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portathon_Hackathon.Server.Migrations
{
    public partial class Init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Companies");
        }
    }
}
