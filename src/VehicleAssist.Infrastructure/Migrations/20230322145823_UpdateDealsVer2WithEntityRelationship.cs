using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleAssist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDealsVer2WithEntityRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Members_CompanyMemberId",
                table: "Deals");

            migrationBuilder.RenameColumn(
                name: "CompanyMemberId",
                table: "Deals",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Deals_CompanyMemberId",
                table: "Deals",
                newName: "IX_Deals_CompanyId");

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

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Deals",
                newName: "CompanyMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Deals_CompanyId",
                table: "Deals",
                newName: "IX_Deals_CompanyMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Members_CompanyMemberId",
                table: "Deals",
                column: "CompanyMemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
