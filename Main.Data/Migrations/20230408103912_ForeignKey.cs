using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Data.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_categoryProperties_CategoryId",
                table: "ProductProperties");

            migrationBuilder.DropIndex(
                name: "IX_ProductProperties_CategoryId",
                table: "ProductProperties");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductProperties");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_PropertyId",
                table: "ProductProperties",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_categoryProperties_PropertyId",
                table: "ProductProperties",
                column: "PropertyId",
                principalTable: "categoryProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_categoryProperties_PropertyId",
                table: "ProductProperties");

            migrationBuilder.DropIndex(
                name: "IX_ProductProperties_PropertyId",
                table: "ProductProperties");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_CategoryId",
                table: "ProductProperties",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_categoryProperties_CategoryId",
                table: "ProductProperties",
                column: "CategoryId",
                principalTable: "categoryProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
