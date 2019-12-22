using Microsoft.EntityFrameworkCore.Migrations;

namespace EngineeringWork.Web.Migrations
{
    public partial class addedbookingProposal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerBooking_DailyRoutes_DailyRouteId",
                table: "PassengerBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PassengerBooking",
                table: "PassengerBooking");

            migrationBuilder.RenameTable(
                name: "PassengerBooking",
                newName: "PassengerBookings");

            migrationBuilder.RenameColumn(
                name: "DailyRouteId",
                table: "PassengerBookings",
                newName: "PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_PassengerBooking_DailyRouteId",
                table: "PassengerBookings",
                newName: "IX_PassengerBookings_PassengerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassengerBookings",
                table: "PassengerBookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerBookings_Passenger_PassengerId",
                table: "PassengerBookings",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerBookings_Passenger_PassengerId",
                table: "PassengerBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PassengerBookings",
                table: "PassengerBookings");

            migrationBuilder.RenameTable(
                name: "PassengerBookings",
                newName: "PassengerBooking");

            migrationBuilder.RenameColumn(
                name: "PassengerId",
                table: "PassengerBooking",
                newName: "DailyRouteId");

            migrationBuilder.RenameIndex(
                name: "IX_PassengerBookings_PassengerId",
                table: "PassengerBooking",
                newName: "IX_PassengerBooking_DailyRouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassengerBooking",
                table: "PassengerBooking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerBooking_DailyRoutes_DailyRouteId",
                table: "PassengerBooking",
                column: "DailyRouteId",
                principalTable: "DailyRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
