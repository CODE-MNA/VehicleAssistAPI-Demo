using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleAssist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompanyServiceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Members_CompanyMemberId",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Members_MemberId",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_CompanyServices_CompanyMemberId",
                table: "CompanyServices");

            migrationBuilder.DropColumn(
                name: "CompanyMemberId",
                table: "CompanyServices");

            migrationBuilder.AddColumn<decimal>(
                name: "ActualPrice",
                table: "CompanyServices",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CompanyServices",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "CompanyServices",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DiscountTypeCode",
                table: "CompanyServices",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "CompanyServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CompanyServices",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CompanyServices",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ServiceTypeCode",
                table: "CompanyServices",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountTypeCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    Description = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTimes",
                columns: table => new
                {
                    ServiceTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyServiceId = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTimes", x => x.ServiceTimeId);
                    table.ForeignKey(
                        name: "FK_ServiceTimes_CompanyServices_CompanyServiceId",
                        column: x => x.CompanyServiceId,
                        principalTable: "CompanyServices",
                        principalColumn: "CompanyServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ServiceTypeCode = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceTypeCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyServices_DiscountTypeCode",
                table: "CompanyServices",
                column: "DiscountTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyServices_MemberId",
                table: "CompanyServices",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyServices_ServiceTypeCode",
                table: "CompanyServices",
                column: "ServiceTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTimes_CompanyServiceId",
                table: "ServiceTimes",
                column: "CompanyServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyServices_Discounts_DiscountTypeCode",
                table: "CompanyServices",
                column: "DiscountTypeCode",
                principalTable: "Discounts",
                principalColumn: "DiscountTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyServices_Members_MemberId",
                table: "CompanyServices",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyServices_ServiceTypes_ServiceTypeCode",
                table: "CompanyServices",
                column: "ServiceTypeCode",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Members_MemberId",
                table: "Deals",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Discounts_DiscountTypeCode",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Members_MemberId",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_ServiceTypes_ServiceTypeCode",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Members_MemberId",
                table: "Deals");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "ServiceTimes");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_CompanyServices_DiscountTypeCode",
                table: "CompanyServices");

            migrationBuilder.DropIndex(
                name: "IX_CompanyServices_MemberId",
                table: "CompanyServices");

            migrationBuilder.DropIndex(
                name: "IX_CompanyServices_ServiceTypeCode",
                table: "CompanyServices");

            migrationBuilder.DropColumn(
                name: "ActualPrice",
                table: "CompanyServices");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CompanyServices");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "CompanyServices");

            migrationBuilder.DropColumn(
                name: "DiscountTypeCode",
                table: "CompanyServices");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "CompanyServices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CompanyServices");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CompanyServices");

            migrationBuilder.DropColumn(
                name: "ServiceTypeCode",
                table: "CompanyServices");

            migrationBuilder.AddColumn<int>(
                name: "CompanyMemberId",
                table: "CompanyServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyServices_CompanyMemberId",
                table: "CompanyServices",
                column: "CompanyMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyServices_Members_CompanyMemberId",
                table: "CompanyServices",
                column: "CompanyMemberId",
                principalTable: "Members",
                principalColumn: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Members_MemberId",
                table: "Deals",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
