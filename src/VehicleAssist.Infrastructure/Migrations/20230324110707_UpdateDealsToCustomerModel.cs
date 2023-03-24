using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleAssist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDealsToCustomerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Members_CompanyId",
                table: "Deals");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Deals",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Deals_CompanyId",
                table: "Deals",
                newName: "IX_Deals_MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Members_MemberId",
                table: "Deals",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Members_MemberId",
                table: "Deals");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Deals",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Deals_MemberId",
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
    }
}
