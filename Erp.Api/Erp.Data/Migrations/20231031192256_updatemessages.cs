using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatemessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Message_DealerId_CompanyId",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Messages",
                schema: "dbo",
                table: "Message");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Message",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "MessageDate",
                schema: "dbo",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ReceiverMessage",
                schema: "dbo",
                table: "Message",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransmitterMessage",
                schema: "dbo",
                table: "Message",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_DealerId_CompanyId",
                schema: "dbo",
                table: "Message",
                columns: new[] { "DealerId", "CompanyId" });

            migrationBuilder.CreateIndex(
                name: "IX_Message_Email",
                schema: "dbo",
                table: "Message",
                column: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Message_DealerId_CompanyId",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_Email",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "MessageDate",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "ReceiverMessage",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "TransmitterMessage",
                schema: "dbo",
                table: "Message");

            migrationBuilder.AddColumn<string>(
                name: "Messages",
                schema: "dbo",
                table: "Message",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Message_DealerId_CompanyId",
                schema: "dbo",
                table: "Message",
                columns: new[] { "DealerId", "CompanyId" },
                unique: true);
        }
    }
}
