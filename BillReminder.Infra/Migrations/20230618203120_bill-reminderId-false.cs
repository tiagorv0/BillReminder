using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillReminder.Infra.Migrations
{
    /// <inheritdoc />
    public partial class billreminderIdfalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bills_ReminderId",
                table: "Bills");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReminderId",
                table: "Bills",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ReminderId",
                table: "Bills",
                column: "ReminderId",
                unique: true,
                filter: "[ReminderId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bills_ReminderId",
                table: "Bills");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReminderId",
                table: "Bills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ReminderId",
                table: "Bills",
                column: "ReminderId",
                unique: true);
        }
    }
}
