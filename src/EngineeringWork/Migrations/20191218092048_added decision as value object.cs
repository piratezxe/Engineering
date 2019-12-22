using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EngineeringWork.Web.Migrations
{
    public partial class addeddecisionasvalueobject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerBookingProposals_PassengerBookingProposalDecision_PassengerBookingProposalDecisionId",
                table: "PassengerBookingProposals");

            migrationBuilder.DropTable(
                name: "PassengerBookingProposalDecision");

            migrationBuilder.DropIndex(
                name: "IX_PassengerBookingProposals_PassengerBookingProposalDecisionId",
                table: "PassengerBookingProposals");

            migrationBuilder.DropColumn(
                name: "PassengerBookingProposalDecisionId",
                table: "PassengerBookingProposals");

            migrationBuilder.AddColumn<DateTime>(
                name: "PassengerBookingProposalDecision_DateTime",
                table: "PassengerBookingProposals",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PassengerBookingProposalDecision_ProposalStatus",
                table: "PassengerBookingProposals",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassengerBookingProposalDecision_RejectReason",
                table: "PassengerBookingProposals",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PassengerBookingProposalDecision_UserId",
                table: "PassengerBookingProposals",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassengerBookingProposalDecision_DateTime",
                table: "PassengerBookingProposals");

            migrationBuilder.DropColumn(
                name: "PassengerBookingProposalDecision_ProposalStatus",
                table: "PassengerBookingProposals");

            migrationBuilder.DropColumn(
                name: "PassengerBookingProposalDecision_RejectReason",
                table: "PassengerBookingProposals");

            migrationBuilder.DropColumn(
                name: "PassengerBookingProposalDecision_UserId",
                table: "PassengerBookingProposals");

            migrationBuilder.AddColumn<Guid>(
                name: "PassengerBookingProposalDecisionId",
                table: "PassengerBookingProposals",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PassengerBookingProposalDecision",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    ProposalStatus = table.Column<string>(nullable: false),
                    RejectReason = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerBookingProposalDecision", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassengerBookingProposals_PassengerBookingProposalDecisionId",
                table: "PassengerBookingProposals",
                column: "PassengerBookingProposalDecisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerBookingProposals_PassengerBookingProposalDecision_PassengerBookingProposalDecisionId",
                table: "PassengerBookingProposals",
                column: "PassengerBookingProposalDecisionId",
                principalTable: "PassengerBookingProposalDecision",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
