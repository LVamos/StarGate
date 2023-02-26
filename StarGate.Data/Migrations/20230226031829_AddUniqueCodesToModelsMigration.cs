using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarGate.Data.Migrations
{
    public partial class AddUniqueCodesToModelsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Team",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Symbol",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Planet",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Code",
                table: "Team",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Symbol_Code",
                table: "Symbol",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planet_Code",
                table: "Planet",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Team_Code",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Symbol_Code",
                table: "Symbol");

            migrationBuilder.DropIndex(
                name: "IX_Planet_Code",
                table: "Planet");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Symbol");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Planet");
        }
    }
}
