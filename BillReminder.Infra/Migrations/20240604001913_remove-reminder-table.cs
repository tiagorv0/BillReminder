using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillReminder.Infra.Migrations
{
    /// <inheritdoc />
    public partial class removeremindertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Reminder",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_Notification",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Bills_ReminderId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "ReminderId",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "ReminderId",
                table: "Notifications",
                newName: "BillId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_ReminderId",
                table: "Notifications",
                newName: "IX_Notifications_BillId");

            migrationBuilder.AddColumn<bool>(
                name: "Reminder",
                table: "Bills",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Notification",
                table: "Notifications",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Notification",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Reminder",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "BillId",
                table: "Notifications",
                newName: "ReminderId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_BillId",
                table: "Notifications",
                newName: "IX_Notifications_ReminderId");

            migrationBuilder.AddColumn<Guid>(
                name: "ReminderId",
                table: "Bills",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BillId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HowManyDaysToRemind = table.Column<int>(type: "integer", nullable: false),
                    HowManyTimes = table.Column<int>(type: "integer", nullable: false),
                    IsEnabled = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ReminderId",
                table: "Bills",
                column: "ReminderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Reminder",
                table: "Bills",
                column: "ReminderId",
                principalTable: "Reminders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_Notification",
                table: "Notifications",
                column: "ReminderId",
                principalTable: "Reminders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
