using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleAssist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatememberconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Members",
                type: "varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Members",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)");
        }
    }
}
