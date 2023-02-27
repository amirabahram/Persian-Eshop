using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Data.Migrations
{
    /// <inheritdoc />
    public partial class addSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Faqs",
                columns: new[] { "Id", "Answer", "CreateDate", "IsDelete", "Question" },
                values: new object[] { 1, "پاسخ سوال اول", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "سوال اول" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
