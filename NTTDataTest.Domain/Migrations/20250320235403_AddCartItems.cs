using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NTTDataTest.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddCartItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Carts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    cartid = table.Column<int>(type: "integer", nullable: false),
                    productid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_CartItem_Carts_cartid",
                        column: x => x.cartid,
                        principalTable: "Carts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Products_productid",
                        column: x => x.productid,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_userid",
                table: "Carts",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_cartid",
                table: "CartItem",
                column: "cartid");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_productid",
                table: "CartItem",
                column: "productid");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_userid",
                table: "Carts",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_userid",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_Carts_userid",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Carts");
        }
    }
}
