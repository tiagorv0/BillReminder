using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillReminder.Infra.Migrations
{
    /// <inheritdoc />
    public partial class changescolunsnotificationbill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Notifications",
                newName: "Title");

            migrationBuilder.AddColumn<bool>(
                name: "Recurrency",
                table: "Bills",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recurrency",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Notifications",
                newName: "Subject");
        }
    }
}
