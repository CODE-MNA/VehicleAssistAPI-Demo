using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleAssist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDealsRemoveMemberId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Members_CompanyMemberId",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Deals");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyMemberId",
                table: "Deals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Members_CompanyMemberId",
                table: "Deals",
                column: "CompanyMemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Members_CompanyMemberId",
                table: "Deals");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyMemberId",
                table: "Deals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Deals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Members_CompanyMemberId",
                table: "Deals",
                column: "CompanyMemberId",
                principalTable: "Members",
                principalColumn: "MemberId");
        }
    }
}
