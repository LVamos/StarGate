using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarGate.Data.Migrations
{
    public partial class FixUniqueKeysInAddressMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Address_Symbol1Id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_Symbol2Id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_Symbol3Id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_Symbol4Id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_Symbol5Id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_Symbol6Id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_Symbol7Id",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Symbol2Id",
                table: "Address",
                column: "Symbol2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Symbol3Id",
                table: "Address",
                column: "Symbol3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Symbol4Id",
                table: "Address",
                column: "Symbol4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Symbol5Id",
                table: "Address",
                column: "Symbol5Id");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Symbol6Id",
                table: "Address",
                column: "Symbol6Id");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Symbol7Id",
                table: "Address",
                column: "Symbol7Id");

            migrationBuilder.CreateIndex(
                name: "My_Unique_Index",
                table: "Address",
                columns: new[] { "Symbol1Id", "Symbol2Id", "Symbol3Id", "Symbol4Id", "Symbol5Id", "Symbol6Id", "Symbol7Id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Address_Symbol2Id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_Symbol3Id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_Symbol4Id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_Symbol5Id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_Symbol6Id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_Symbol7Id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "My_Unique_Index",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Symbol1Id",
                table: "Address",
                column: "Symbol1Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_Symbol2Id",
                table: "Address",
                column: "Symbol2Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_Symbol3Id",
                table: "Address",
                column: "Symbol3Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_Symbol4Id",
                table: "Address",
                column: "Symbol4Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_Symbol5Id",
                table: "Address",
                column: "Symbol5Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_Symbol6Id",
                table: "Address",
                column: "Symbol6Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_Symbol7Id",
                table: "Address",
                column: "Symbol7Id",
                unique: true);
        }
    }
}
