using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium.Migrations
{
    public partial class fixes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Champinship_Team_Championship_IdChampionship",
                table: "Champinship_Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Champinship_Team_ChampionshipTeamIdTeam_ChampionshipTeamIdChampionship",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_ChampionshipTeamIdTeam_ChampionshipTeamIdChampionship",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Champinship_Team_IdChampionship",
                table: "Champinship_Team");

            migrationBuilder.DropColumn(
                name: "ChampionshipTeamIdChampionship",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "ChampionshipTeamIdTeam",
                table: "Team");

            migrationBuilder.AddColumn<int>(
                name: "ChampionshipIdChampionship",
                table: "Champinship_Team",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Champinship_Team_ChampionshipIdChampionship",
                table: "Champinship_Team",
                column: "ChampionshipIdChampionship");

            migrationBuilder.CreateIndex(
                name: "IX_Champinship_Team_IdTeam",
                table: "Champinship_Team",
                column: "IdTeam",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Champinship_Team_Championship_ChampionshipIdChampionship",
                table: "Champinship_Team",
                column: "ChampionshipIdChampionship",
                principalTable: "Championship",
                principalColumn: "IdChampionship",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Champinship_Team_Team_IdTeam",
                table: "Champinship_Team",
                column: "IdTeam",
                principalTable: "Team",
                principalColumn: "IdTeam",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Champinship_Team_Championship_ChampionshipIdChampionship",
                table: "Champinship_Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Champinship_Team_Team_IdTeam",
                table: "Champinship_Team");

            migrationBuilder.DropIndex(
                name: "IX_Champinship_Team_ChampionshipIdChampionship",
                table: "Champinship_Team");

            migrationBuilder.DropIndex(
                name: "IX_Champinship_Team_IdTeam",
                table: "Champinship_Team");

            migrationBuilder.DropColumn(
                name: "ChampionshipIdChampionship",
                table: "Champinship_Team");

            migrationBuilder.AddColumn<int>(
                name: "ChampionshipTeamIdChampionship",
                table: "Team",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChampionshipTeamIdTeam",
                table: "Team",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_ChampionshipTeamIdTeam_ChampionshipTeamIdChampionship",
                table: "Team",
                columns: new[] { "ChampionshipTeamIdTeam", "ChampionshipTeamIdChampionship" });

            migrationBuilder.CreateIndex(
                name: "IX_Champinship_Team_IdChampionship",
                table: "Champinship_Team",
                column: "IdChampionship");

            migrationBuilder.AddForeignKey(
                name: "FK_Champinship_Team_Championship_IdChampionship",
                table: "Champinship_Team",
                column: "IdChampionship",
                principalTable: "Championship",
                principalColumn: "IdChampionship",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Champinship_Team_ChampionshipTeamIdTeam_ChampionshipTeamIdChampionship",
                table: "Team",
                columns: new[] { "ChampionshipTeamIdTeam", "ChampionshipTeamIdChampionship" },
                principalTable: "Champinship_Team",
                principalColumns: new[] { "IdTeam", "IdChampionship" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
