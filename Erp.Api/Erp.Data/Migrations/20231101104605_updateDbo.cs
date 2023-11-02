using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateDbo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DealerId",
                schema: "dbo",
                table: "OrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_DealerId",
                schema: "dbo",
                table: "OrderItem",
                column: "DealerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Dealer_DealerId",
                schema: "dbo",
                table: "OrderItem",
                column: "DealerId",
                principalSchema: "dbo",
                principalTable: "Dealer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Dealer_DealerId",
                schema: "dbo",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_DealerId",
                schema: "dbo",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "DealerId",
                schema: "dbo",
                table: "OrderItem");
        }
    }
}
