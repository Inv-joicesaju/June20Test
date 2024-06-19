using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace June20Test.Migrations
{
    public partial class UpdateProduct2stablecahngeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Product2Id",
                table: "Product2s",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Product2s",
                newName: "Product2Id");
        }
    }
}
