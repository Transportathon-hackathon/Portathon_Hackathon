using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portathon_Hackathon.Server.Migrations
{
    public partial class MessageSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverMessage",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "SenderMessage",
                table: "Message",
                newName: "Content");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeSpan",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "TimeSpan",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Message",
                newName: "SenderMessage");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverMessage",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
