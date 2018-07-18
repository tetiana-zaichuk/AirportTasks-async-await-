using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddedLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Pilots_PilotId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Stewardesses_Crews_CrewId",
                table: "Stewardesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Flights_FlightId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Crews_PilotId",
                table: "Crews");

            migrationBuilder.DropColumn(
                name: "PilotId",
                table: "Crews");

            migrationBuilder.AlterColumn<int>(
                name: "FlightId",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CrewId",
                table: "Stewardesses",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CrewId",
                table: "Pilots",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartureId",
                table: "Flights",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartureId",
                table: "Crews",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartureId",
                table: "Aircrafts",
                nullable: true,
                defaultValue: 0);
            /*
            migrationBuilder.CreateIndex(
                name: "IX_Pilots_CrewId",
                table: "Pilots",
                column: "CrewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DepartureId",
                table: "Flights",
                column: "DepartureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crews_DepartureId",
                table: "Crews",
                column: "DepartureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_DepartureId",
                table: "Aircrafts",
                column: "DepartureId",
                unique: true);*/

            migrationBuilder.AddForeignKey(
                name: "FK_Aircrafts_Departures_DepartureId",
                table: "Aircrafts",
                column: "DepartureId",
                principalTable: "Departures",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Departures_DepartureId",
                table: "Crews",
                column: "DepartureId",
                principalTable: "Departures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Departures_DepartureId",
                table: "Flights",
                column: "DepartureId",
                principalTable: "Departures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pilots_Crews_CrewId",
                table: "Pilots",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stewardesses_Crews_CrewId",
                table: "Stewardesses",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Flights_FlightId",
                table: "Tickets",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircrafts_Departures_DepartureId",
                table: "Aircrafts");

            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Departures_DepartureId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Departures_DepartureId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Pilots_Crews_CrewId",
                table: "Pilots");

            migrationBuilder.DropForeignKey(
                name: "FK_Stewardesses_Crews_CrewId",
                table: "Stewardesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Flights_FlightId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Pilots_CrewId",
                table: "Pilots");
            /*
            migrationBuilder.DropIndex(
                name: "IX_Flights_DepartureId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Crews_DepartureId",
                table: "Crews");

            migrationBuilder.DropIndex(
                name: "IX_Aircrafts_DepartureId",
                table: "Aircrafts");*/

            migrationBuilder.DropColumn(
                name: "CrewId",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "DepartureId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureId",
                table: "Crews");

            migrationBuilder.DropColumn(
                name: "DepartureId",
                table: "Aircrafts");

            migrationBuilder.AlterColumn<int>(
                name: "FlightId",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CrewId",
                table: "Stewardesses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PilotId",
                table: "Crews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crews_PilotId",
                table: "Crews",
                column: "PilotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Pilots_PilotId",
                table: "Crews",
                column: "PilotId",
                principalTable: "Pilots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stewardesses_Crews_CrewId",
                table: "Stewardesses",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Flights_FlightId",
                table: "Tickets",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
