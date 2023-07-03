using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillReminder.Infra.Migrations
{
    /// <inheritdoc />
    public partial class fixCategoryrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_User",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Categories",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                newName: "IX_Categories_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Account",
                table: "Categories",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Account",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Categories",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_AccountId",
                table: "Categories",
                newName: "IX_Categories_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_User",
                table: "Categories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
