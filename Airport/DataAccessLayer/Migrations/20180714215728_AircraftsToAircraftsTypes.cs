using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AircraftsToAircraftsTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircrafts_AircraftsTypes_AircraftTypeId",
                table: "Aircrafts");

            migrationBuilder.DropIndex(
                name: "IX_Aircrafts_AircraftTypeId",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "AircraftTypeId",
                table: "Aircrafts");

            migrationBuilder.AddColumn<int>(
                name: "AircraftId",
                table: "AircraftsTypes",
                nullable: false,
                defaultValue: 0);

            /*migrationBuilder.CreateIndex(
                name: "IX_AircraftsTypes_AircraftId",
                table: "AircraftsTypes",
                column: "AircraftId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AircraftsTypes_Aircrafts_AircraftId",
                table: "AircraftsTypes",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AircraftsTypes_Aircrafts_AircraftId",
                table: "AircraftsTypes");

            migrationBuilder.DropIndex(
                name: "IX_AircraftsTypes_AircraftId",
                table: "AircraftsTypes");

            migrationBuilder.DropColumn(
                name: "AircraftId",
                table: "AircraftsTypes");

            migrationBuilder.AddColumn<int>(
                name: "AircraftTypeId",
                table: "Aircrafts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_AircraftTypeId",
                table: "Aircrafts",
                column: "AircraftTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aircrafts_AircraftsTypes_AircraftTypeId",
                table: "Aircrafts",
                column: "AircraftTypeId",
                principalTable: "AircraftsTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
