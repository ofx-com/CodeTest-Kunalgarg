using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ofx.Battleship.Data.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Ofx");

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "Ofx",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    CreatedByUsername = table.Column<string>(nullable: true),
                    ModifiedByUsername = table.Column<string>(nullable: true),
                    BoardX = table.Column<int>(nullable: false),
                    BoardY = table.Column<int>(nullable: false),
                    NextTurnPlayerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "Ofx",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    CreatedByUsername = table.Column<string>(nullable: true),
                    ModifiedByUsername = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    GameId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "Ofx",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                schema: "Ofx",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    CreatedByUsername = table.Column<string>(nullable: true),
                    ModifiedByUsername = table.Column<string>(nullable: true),
                    DimensionX = table.Column<int>(nullable: false),
                    DimensionY = table.Column<int>(nullable: false),
                    Location_X = table.Column<int>(nullable: true),
                    Location_Y = table.Column<int>(nullable: true),
                    PlayerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Ofx",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipParts",
                schema: "Ofx",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    CreatedByUsername = table.Column<string>(nullable: true),
                    ModifiedByUsername = table.Column<string>(nullable: true),
                    Location_X = table.Column<int>(nullable: true),
                    Location_Y = table.Column<int>(nullable: true),
                    IsAlive = table.Column<bool>(nullable: false),
                    ShipId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipParts_Ships_ShipId",
                        column: x => x.ShipId,
                        principalSchema: "Ofx",
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameId",
                schema: "Ofx",
                table: "Players",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipParts_ShipId",
                schema: "Ofx",
                table: "ShipParts",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_PlayerId",
                schema: "Ofx",
                table: "Ships",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShipParts",
                schema: "Ofx");

            migrationBuilder.DropTable(
                name: "Ships",
                schema: "Ofx");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "Ofx");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "Ofx");
        }
    }
}
