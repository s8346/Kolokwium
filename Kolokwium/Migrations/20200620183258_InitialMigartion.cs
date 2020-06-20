using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium.Migrations
{
    public partial class InitialMigartion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Championship",
                columns: table => new
                {
                    IdChampionship = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficialName = table.Column<string>(maxLength: 100, nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship", x => x.IdChampionship);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.IdPlayer);
                });

            migrationBuilder.CreateTable(
                name: "Champinship_Team",
                columns: table => new
                {
                    IdTeam = table.Column<int>(nullable: false),
                    IdChampionship = table.Column<int>(nullable: false),
                    Score = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champinship_Team", x => new { x.IdTeam, x.IdChampionship });
                    table.ForeignKey(
                        name: "FK_Champinship_Team_Championship_IdChampionship",
                        column: x => x.IdChampionship,
                        principalTable: "Championship",
                        principalColumn: "IdChampionship",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    IdTeam = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(maxLength: 30, nullable: true),
                    MaxAge = table.Column<int>(nullable: false),
                    ChampionshipTeamIdTeam = table.Column<int>(nullable: true),
                    ChampionshipTeamIdChampionship = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.IdTeam);
                    table.ForeignKey(
                        name: "FK_Team_Champinship_Team_ChampionshipTeamIdTeam_ChampionshipTeamIdChampionship",
                        columns: x => new { x.ChampionshipTeamIdTeam, x.ChampionshipTeamIdChampionship },
                        principalTable: "Champinship_Team",
                        principalColumns: new[] { "IdTeam", "IdChampionship" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player_Team",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(nullable: false),
                    IdTeam = table.Column<int>(nullable: false),
                    NumOnShirt = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Team", x => new { x.IdPlayer, x.IdTeam });
                    table.ForeignKey(
                        name: "FK_Player_Team_Player_IdPlayer",
                        column: x => x.IdPlayer,
                        principalTable: "Player",
                        principalColumn: "IdPlayer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player_Team_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Champinship_Team_IdChampionship",
                table: "Champinship_Team",
                column: "IdChampionship");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Team_IdTeam",
                table: "Player_Team",
                column: "IdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Team_ChampionshipTeamIdTeam_ChampionshipTeamIdChampionship",
                table: "Team",
                columns: new[] { "ChampionshipTeamIdTeam", "ChampionshipTeamIdChampionship" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player_Team");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Champinship_Team");

            migrationBuilder.DropTable(
                name: "Championship");
        }
    }
}
