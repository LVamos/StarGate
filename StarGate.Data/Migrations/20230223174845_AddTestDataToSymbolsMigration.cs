using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarGate.Data.Migrations
{
    public partial class AddTestDataToSymbolsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Symbol",
                columns: new[] { "Id", "ImageName", "ImageURI", "Name" },
                values: new object[] { 1L, "losos.jpg", "https://localhost:7230/images/losos.jpg", "losos" });

            migrationBuilder.InsertData(
                table: "Symbol",
                columns: new[] { "Id", "ImageName", "ImageURI", "Name" },
                values: new object[] { 2L, "kot.jpg", "https://localhost:7230/images/kot.jpg", "kot" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Symbol",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Symbol",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
