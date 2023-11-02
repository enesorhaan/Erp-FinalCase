using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderItem_OrderId_ProductId",
                schema: "dbo",
                table: "OrderItem");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId_ProductId",
                schema: "dbo",
                table: "OrderItem",
                columns: new[] { "OrderId", "ProductId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderItem_OrderId_ProductId",
                schema: "dbo",
                table: "OrderItem");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId_ProductId",
                schema: "dbo",
                table: "OrderItem",
                columns: new[] { "OrderId", "ProductId" },
                unique: true);
        }
    }
}
