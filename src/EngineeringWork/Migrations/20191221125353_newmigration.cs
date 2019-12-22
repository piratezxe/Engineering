using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EngineeringWork.Web.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passenger_Adress_AddressId",
                table: "Passenger");

            migrationBuilder.DropForeignKey(
                name: "FK_PassengerBookings_Passenger_PassengerId",
                table: "PassengerBookings");

            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropIndex(
                name: "IX_PassengerBookings_PassengerId",
                table: "PassengerBookings");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "PassengerBookings");

            migrationBuilder.RenameColumn(
                name: "BeginingDate",
                table: "DailyRoutes",
                newName: "StartDate");

            migrationBuilder.AddColumn<string>(
                name: "FromPlace",
                table: "PassengerBookings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PassengerBookings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PassengerName",
                table: "PassengerBookings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "PassengerBookings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ToPlace",
                table: "PassengerBookings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassengerBookingProposals_DailyRouteId",
                table: "PassengerBookingProposals",
                column: "DailyRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passenger_Address_AddressId",
                table: "Passenger",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerBookingProposals_DailyRoutes_DailyRouteId",
                table: "PassengerBookingProposals",
                column: "DailyRouteId",
                principalTable: "DailyRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passenger_Address_AddressId",
                table: "Passenger");

            migrationBuilder.DropForeignKey(
                name: "FK_PassengerBookingProposals_DailyRoutes_DailyRouteId",
                table: "PassengerBookingProposals");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_PassengerBookingProposals_DailyRouteId",
                table: "PassengerBookingProposals");

            migrationBuilder.DropColumn(
                name: "FromPlace",
                table: "PassengerBookings");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PassengerBookings");

            migrationBuilder.DropColumn(
                name: "PassengerName",
                table: "PassengerBookings");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "PassengerBookings");

            migrationBuilder.DropColumn(
                name: "ToPlace",
                table: "PassengerBookings");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "DailyRoutes",
                newName: "BeginingDate");

            migrationBuilder.AddColumn<Guid>(
                name: "PassengerId",
                table: "PassengerBookings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassengerBookings_PassengerId",
                table: "PassengerBookings",
                column: "PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passenger_Adress_AddressId",
                table: "Passenger",
                column: "AddressId",
                principalTable: "Adress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerBookings_Passenger_PassengerId",
                table: "PassengerBookings",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
