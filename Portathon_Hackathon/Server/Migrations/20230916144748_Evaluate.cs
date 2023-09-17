using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portathon_Hackathon.Server.Migrations
{
    public partial class Evaluate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Reservations_ReservationId",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_ReservationId",
                table: "Evaluations");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Evaluations",
                newName: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_CompanyId",
                table: "Evaluations",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Companies_CompanyId",
                table: "Evaluations",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Companies_CompanyId",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_CompanyId",
                table: "Evaluations");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Evaluations",
                newName: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ReservationId",
                table: "Evaluations",
                column: "ReservationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Reservations_ReservationId",
                table: "Evaluations",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
