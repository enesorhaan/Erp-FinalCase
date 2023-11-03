using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_BillingNumber",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "BillingNumber",
                schema: "dbo",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingNumber",
                schema: "dbo",
                table: "Orders",
                column: "BillingNumber",
                unique: true,
                filter: "[BillingNumber] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_BillingNumber",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "BillingNumber",
                schema: "dbo",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingNumber",
                schema: "dbo",
                table: "Orders",
                column: "BillingNumber",
                unique: true);
        }
    }
}
