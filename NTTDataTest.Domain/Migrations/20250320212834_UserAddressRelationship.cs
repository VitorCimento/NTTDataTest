using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTTDataTest.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UserAddressRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "addressid",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_addressid",
                table: "Users",
                column: "addressid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_addressid",
                table: "Users",
                column: "addressid",
                principalTable: "Addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_addressid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_addressid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "addressid",
                table: "Users");
        }
    }
}
