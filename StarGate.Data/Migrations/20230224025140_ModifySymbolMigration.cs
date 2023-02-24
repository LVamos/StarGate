using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarGate.Data.Migrations
{
    public partial class ModifySymbolMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Symbol",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Symbol",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Symbol");

            migrationBuilder.DropColumn(
                name: "ImageURI",
                table: "Symbol");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Symbol",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Symbol");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Symbol",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageURI",
                table: "Symbol",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Symbol",
                columns: new[] { "Id", "ImageName", "ImageURI", "Name" },
                values: new object[] { 1L, "losos.jpg", "https://localhost:7230/images/losos.jpg", "losos" });

            migrationBuilder.InsertData(
                table: "Symbol",
                columns: new[] { "Id", "ImageName", "ImageURI", "Name" },
                values: new object[] { 2L, "kot.jpg", "https://localhost:7230/images/kot.jpg", "kot" });
        }
    }
}
