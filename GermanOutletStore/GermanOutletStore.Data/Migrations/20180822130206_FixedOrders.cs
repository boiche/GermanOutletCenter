using Microsoft.EntityFrameworkCore.Migrations;

namespace GermanOutletStore.Data.Migrations
{
    public partial class FixedOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrders",
                table: "ProductOrders");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "ProductOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrders",
                table: "ProductOrders",
                columns: new[] { "OrderId", "ProductId", "SizeId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_SizeId",
                table: "ProductOrders",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_Sizes_SizeId",
                table: "ProductOrders",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Sizes_SizeId",
                table: "ProductOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrders",
                table: "ProductOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrders_SizeId",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "ProductOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrders",
                table: "ProductOrders",
                columns: new[] { "OrderId", "ProductId" });
        }
    }
}
