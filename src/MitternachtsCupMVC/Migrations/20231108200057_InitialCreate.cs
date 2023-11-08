using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MitternachtsCupMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spiele",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Platte = table.Column<int>(type: "INTEGER", nullable: false),
                    StartZeit = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SpielDauer = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    TeamAId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamBId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spiele", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spiele_Teams_TeamAId",
                        column: x => x.TeamAId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spiele_Teams_TeamBId",
                        column: x => x.TeamBId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ergebnisse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PunkteTeamA = table.Column<int>(type: "INTEGER", nullable: false),
                    PunkteTeamB = table.Column<int>(type: "INTEGER", nullable: false),
                    SpielId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ergebnisse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ergebnisse_Spiele_SpielId",
                        column: x => x.SpielId,
                        principalTable: "Spiele",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ergebnisse_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ergebnisse_SpielId",
                table: "Ergebnisse",
                column: "SpielId");

            migrationBuilder.CreateIndex(
                name: "IX_Ergebnisse_TeamId",
                table: "Ergebnisse",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Spiele_TeamAId",
                table: "Spiele",
                column: "TeamAId");

            migrationBuilder.CreateIndex(
                name: "IX_Spiele_TeamBId",
                table: "Spiele",
                column: "TeamBId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ergebnisse");

            migrationBuilder.DropTable(
                name: "Spiele");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
