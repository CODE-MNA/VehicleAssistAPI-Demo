using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleAssist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedrefidfornotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "Notifications");
        }
    }
}
