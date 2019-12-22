using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EngineeringWork.Web.Migrations
{
    public partial class removeidpropertiesfromproposalstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassengerBookingProposalDecision_UserId",
                table: "PassengerBookingProposals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PassengerBookingProposalDecision_UserId",
                table: "PassengerBookingProposals",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
