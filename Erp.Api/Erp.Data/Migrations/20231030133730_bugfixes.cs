using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Data.Migrations
{
    /// <inheritdoc />
    public partial class bugfixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Dealer_DealerId",
                schema: "dbo",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                schema: "dbo",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                schema: "dbo",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                schema: "dbo",
                newName: "Orders",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DealerId",
                schema: "dbo",
                table: "Orders",
                newName: "IX_Orders_DealerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_BillingNumber",
                schema: "dbo",
                table: "Orders",
                newName: "IX_Orders_BillingNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                schema: "dbo",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                schema: "dbo",
                table: "OrderItem",
                column: "OrderId",
                principalSchema: "dbo",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dealer_DealerId",
                schema: "dbo",
                table: "Orders",
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
                name: "FK_OrderItem_Orders_OrderId",
                schema: "dbo",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dealer_DealerId",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "dbo",
                newName: "Order",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DealerId",
                schema: "dbo",
                table: "Order",
                newName: "IX_Order_DealerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BillingNumber",
                schema: "dbo",
                table: "Order",
                newName: "IX_Order_BillingNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                schema: "dbo",
                table: "Order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Dealer_DealerId",
                schema: "dbo",
                table: "Order",
                column: "DealerId",
                principalSchema: "dbo",
                principalTable: "Dealer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                schema: "dbo",
                table: "OrderItem",
                column: "OrderId",
                principalSchema: "dbo",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
