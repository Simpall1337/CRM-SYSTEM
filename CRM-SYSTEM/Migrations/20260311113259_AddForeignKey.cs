using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_SYSTEM.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_client_id",
                table: "Orders",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_status_order_id",
                table: "Orders",
                column: "status_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_user_id",
                table: "Orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_product_id",
                table: "Inventory",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_product_id",
                table: "Inventory",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_client_id",
                table: "Orders",
                column: "client_id",
                principalTable: "Clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_StatusOrder_status_order_id",
                table: "Orders",
                column: "status_order_id",
                principalTable: "StatusOrder",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_user_id",
                table: "Orders",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_product_id",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_client_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_StatusOrder_status_order_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_user_id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_client_id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_status_order_id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_user_id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_product_id",
                table: "Inventory");
        }
    }
}
