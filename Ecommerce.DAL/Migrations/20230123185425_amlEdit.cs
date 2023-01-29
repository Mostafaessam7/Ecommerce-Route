using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.DAL.Migrations
{
    public partial class amlEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Order_orderId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Customer_orderId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_orderId",
                table: "Customer",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Order_orderId",
                table: "Customer",
                column: "orderId",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
