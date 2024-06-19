using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace June20Test.Migrations
{
    public partial class UpdateProduct2stable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order2s_Products_ProductId",
                table: "order2s");

            migrationBuilder.DropIndex(
                name: "IX_order2s_ProductId",
                table: "order2s");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Product2s",
                newName: "Product2Id");

            migrationBuilder.AddColumn<int>(
                name: "Product2Id",
                table: "order2s",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_order2s_Product2Id",
                table: "order2s",
                column: "Product2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_order2s_Product2s_Product2Id",
                table: "order2s",
                column: "Product2Id",
                principalTable: "Product2s",
                principalColumn: "Product2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order2s_Product2s_Product2Id",
                table: "order2s");

            migrationBuilder.DropIndex(
                name: "IX_order2s_Product2Id",
                table: "order2s");

            migrationBuilder.DropColumn(
                name: "Product2Id",
                table: "order2s");

            migrationBuilder.RenameColumn(
                name: "Product2Id",
                table: "Product2s",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_order2s_ProductId",
                table: "order2s",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_order2s_Products_ProductId",
                table: "order2s",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
