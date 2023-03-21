using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleAssist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDealsConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Members_CompanyMemberId",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Deals_CompanyMemberId",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "CompanyMemberId",
                table: "Deals");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Deals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Deals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DealName",
                table: "Deals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Deals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Deals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Deals_CompanyId",
                table: "Deals",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Members_CompanyId",
                table: "Deals",
                column: "CompanyId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Members_CompanyId",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Deals_CompanyId",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "DealName",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Deals");

            migrationBuilder.AddColumn<int>(
                name: "CompanyMemberId",
                table: "Deals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deals_CompanyMemberId",
                table: "Deals",
                column: "CompanyMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Members_CompanyMemberId",
                table: "Deals",
                column: "CompanyMemberId",
                principalTable: "Members",
                principalColumn: "MemberId");
        }
    }
}
