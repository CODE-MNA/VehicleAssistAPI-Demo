using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleAssist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAppointmentAndFixedReminder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_CompanyServices_CompanyServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Members_CustomerMemberId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_Members_CustomerMemberId",
                table: "Reminders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reminders",
                table: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CustomerMemberId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CustomerMemberId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "CustomerMemberId",
                table: "Reminders",
                newName: "CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Reminders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyServiceId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AlarmYN",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reminders",
                table: "Reminders",
                column: "ReminderId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CustomerId",
                table: "Vehicles",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_CustomerId",
                table: "Reminders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_VehicleId",
                table: "Reminders",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_CompanyServices_CompanyServiceId",
                table: "Appointments",
                column: "CompanyServiceId",
                principalTable: "CompanyServices",
                principalColumn: "CompanyServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Members_CustomerId",
                table: "Appointments",
                column: "CustomerId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_Members_CustomerId",
                table: "Reminders",
                column: "CustomerId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_Vehicles_VehicleId",
                table: "Reminders",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_CompanyServices_CompanyServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Members_CustomerId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_Members_CustomerId",
                table: "Reminders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_Vehicles_VehicleId",
                table: "Reminders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CustomerId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reminders",
                table: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Reminders_CustomerId",
                table: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Reminders_VehicleId",
                table: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Reminders");

            migrationBuilder.DropColumn(
                name: "AlarmYN",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Reminders",
                newName: "CustomerMemberId");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyServiceId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerMemberId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                columns: new[] { "CustomerId", "VehicleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reminders",
                table: "Reminders",
                columns: new[] { "CustomerMemberId", "ReminderId" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerMemberId",
                table: "Appointments",
                column: "CustomerMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_CompanyServices_CompanyServiceId",
                table: "Appointments",
                column: "CompanyServiceId",
                principalTable: "CompanyServices",
                principalColumn: "CompanyServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Members_CustomerMemberId",
                table: "Appointments",
                column: "CustomerMemberId",
                principalTable: "Members",
                principalColumn: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_Members_CustomerMemberId",
                table: "Reminders",
                column: "CustomerMemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
