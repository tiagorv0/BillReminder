using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillReminder.Infra.Migrations
{
    /// <inheritdoc />
    public partial class fixrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_User",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Bill",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_Bill",
                table: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Reminders_BillId",
                table: "Reminders");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ReminderId",
                table: "Bills",
                column: "ReminderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Account",
                table: "Accounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Reminder",
                table: "Bills",
                column: "ReminderId",
                principalTable: "Reminders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Bill",
                table: "Bills",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Account",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Reminder",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Bill",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_ReminderId",
                table: "Bills");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_BillId",
                table: "Reminders",
                column: "BillId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_User",
                table: "Accounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Bill",
                table: "Bills",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_Bill",
                table: "Reminders",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
