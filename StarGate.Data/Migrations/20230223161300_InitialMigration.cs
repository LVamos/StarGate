using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarGate.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Symbol",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Members = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol1Id = table.Column<long>(type: "bigint", nullable: false),
                    Symbol2Id = table.Column<long>(type: "bigint", nullable: false),
                    Symbol3Id = table.Column<long>(type: "bigint", nullable: false),
                    Symbol4Id = table.Column<long>(type: "bigint", nullable: false),
                    Symbol5Id = table.Column<long>(type: "bigint", nullable: false),
                    Symbol6Id = table.Column<long>(type: "bigint", nullable: false),
                    Symbol7Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Symbol_Symbol1Id",
                        column: x => x.Symbol1Id,
                        principalTable: "Symbol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Symbol_Symbol2Id",
                        column: x => x.Symbol2Id,
                        principalTable: "Symbol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Symbol_Symbol3Id",
                        column: x => x.Symbol3Id,
                        principalTable: "Symbol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Symbol_Symbol4Id",
                        column: x => x.Symbol4Id,
                        principalTable: "Symbol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Symbol_Symbol5Id",
                        column: x => x.Symbol5Id,
                        principalTable: "Symbol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Symbol_Symbol6Id",
                        column: x => x.Symbol6Id,
                        principalTable: "Symbol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Symbol_Symbol7Id",
                        column: x => x.Symbol7Id,
                        principalTable: "Symbol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Planet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Explored = table.Column<bool>(type: "bit", nullable: false),
                    TeamId = table.Column<long>(type: "bigint", nullable: false),
                    Safety = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planet_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planet_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Type = table.Column<int>(type: "int", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Request_Planet_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Planet_AddressId",
                table: "Planet",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Planet_TeamId",
                table: "Planet",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_PlanetId",
                table: "Request",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_Symbol_Name",
                table: "Symbol",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_Name",
                table: "Team",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Planet");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Symbol");
        }
    }
}
