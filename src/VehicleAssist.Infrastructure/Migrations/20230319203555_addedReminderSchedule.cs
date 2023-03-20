using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleAssist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedReminderSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReminderAlarmSchedule",
                columns: table => new
                {
                    ReminderAlarmScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReminderId = table.Column<int>(type: "int", nullable: false),
                    TimePrior = table.Column<float>(type: "real", nullable: false),
                    ScheduleType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderAlarmSchedule", x => x.ReminderAlarmScheduleId);
                    table.ForeignKey(
                        name: "FK_ReminderAlarmSchedule_Reminders_ReminderId",
                        column: x => x.ReminderId,
                        principalTable: "Reminders",
                        principalColumn: "ReminderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_Email",
                table: "Members",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_UserName",
                table: "Members",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReminderAlarmSchedule_ReminderId",
                table: "ReminderAlarmSchedule",
                column: "ReminderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReminderAlarmSchedule");

            migrationBuilder.DropIndex(
                name: "IX_Members_Email",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_UserName",
                table: "Members");
        }
    }
}
