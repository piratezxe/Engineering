using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EngineeringWork.Web.Migrations
{
    public partial class bookingChanging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerBooking_Booking_BookingId",
                table: "PassengerBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_PassengerBooking_DailyRoutes_DailyRouteId",
                table: "PassengerBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_PassengerBooking_Passenger_PassengerId",
                table: "PassengerBooking");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_PassengerBooking_BookingId",
                table: "PassengerBooking");

            migrationBuilder.DropIndex(
                name: "IX_PassengerBooking_PassengerId",
                table: "PassengerBooking");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "PassengerBooking");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "PassengerBooking");

            migrationBuilder.RenameColumn(
                name: "UserPropsalId",
                table: "PassengerBookingProposals",
                newName: "UserProposalId");

            migrationBuilder.AddColumn<Guid>(
                name: "DailyRouteId",
                table: "PassengerBookingProposals",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "SeatsQuantity",
                table: "PassengerBookingProposals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "DailyRouteId",
                table: "PassengerBooking",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "DriverPhoneNumber",
                table: "PassengerBooking",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PassengerBookingProposalId",
                table: "PassengerBooking",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Drivers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerBooking_DailyRoutes_DailyRouteId",
                table: "PassengerBooking",
                column: "DailyRouteId",
                principalTable: "DailyRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerBooking_DailyRoutes_DailyRouteId",
                table: "PassengerBooking");

            migrationBuilder.DropColumn(
                name: "DailyRouteId",
                table: "PassengerBookingProposals");

            migrationBuilder.DropColumn(
                name: "SeatsQuantity",
                table: "PassengerBookingProposals");

            migrationBuilder.DropColumn(
                name: "DriverPhoneNumber",
                table: "PassengerBooking");

            migrationBuilder.DropColumn(
                name: "PassengerBookingProposalId",
                table: "PassengerBooking");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "UserProposalId",
                table: "PassengerBookingProposals",
                newName: "UserPropsalId");

            migrationBuilder.AlterColumn<Guid>(
                name: "DailyRouteId",
                table: "PassengerBooking",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BookingId",
                table: "PassengerBooking",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PassengerId",
                table: "PassengerBooking",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassengerBooking_BookingId",
                table: "PassengerBooking",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerBooking_PassengerId",
                table: "PassengerBooking",
                column: "PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerBooking_Booking_BookingId",
                table: "PassengerBooking",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerBooking_DailyRoutes_DailyRouteId",
                table: "PassengerBooking",
                column: "DailyRouteId",
                principalTable: "DailyRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerBooking_Passenger_PassengerId",
                table: "PassengerBooking",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
