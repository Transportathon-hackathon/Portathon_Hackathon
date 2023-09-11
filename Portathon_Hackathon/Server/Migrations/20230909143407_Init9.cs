using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portathon_Hackathon.Server.Migrations
{
    public partial class Init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_VehicleId",
                table: "Requests",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Vehicles_VehicleId",
                table: "Requests",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Vehicles_VehicleId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_VehicleId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Requests");
        }
    }
}
