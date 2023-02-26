using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarGate.Data.Migrations
{
    public partial class DeleteIndexesInAddressMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "My_Unique_Index",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Symbol1Id",
                table: "Address",
                column: "Symbol1Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Address_Symbol1Id",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "My_Unique_Index",
                table: "Address",
                columns: new[] { "Symbol1Id", "Symbol2Id", "Symbol3Id", "Symbol4Id", "Symbol5Id", "Symbol6Id", "Symbol7Id" },
                unique: true);
        }
    }
}
