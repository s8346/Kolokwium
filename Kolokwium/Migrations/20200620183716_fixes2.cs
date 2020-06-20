using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium.Migrations
{
    public partial class fixes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Champinship_Team_Championship_ChampionshipIdChampionship",
                table: "Champinship_Team");

            migrationBuilder.DropIndex(
                name: "IX_Champinship_Team_ChampionshipIdChampionship",
                table: "Champinship_Team");

            migrationBuilder.DropColumn(
                name: "ChampionshipIdChampionship",
                table: "Champinship_Team");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Champinship_Team_Championship_IdChampionship",
                table: "Champinship_Team");

            migrationBuilder.DropIndex(
                name: "IX_Champinship_Team_IdChampionship",
                table: "Champinship_Team");

            migrationBuilder.AddColumn<int>(
                name: "ChampionshipIdChampionship",
                table: "Champinship_Team",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Champinship_Team_ChampionshipIdChampionship",
                table: "Champinship_Team",
                column: "ChampionshipIdChampionship");

            migrationBuilder.AddForeignKey(
                name: "FK_Champinship_Team_Championship_ChampionshipIdChampionship",
                table: "Champinship_Team",
                column: "ChampionshipIdChampionship",
                principalTable: "Championship",
                principalColumn: "IdChampionship",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
