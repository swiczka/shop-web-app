using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_web_app.Migrations
{
    /// <inheritdoc />
    public partial class AddedProductAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AuthorId",
                table: "Products",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_AuthorId",
                table: "Products",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_AuthorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AuthorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Products");
        }
    }
}
