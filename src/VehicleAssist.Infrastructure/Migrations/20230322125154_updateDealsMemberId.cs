using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleAssist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateDealsMemberId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Members_CompanyId",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Deals_CompanyId",
                table: "Deals");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Deals",
                newName: "MemberId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Deals",
                newName: "CompanyId");

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
    }
}
