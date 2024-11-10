using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_web_app.Migrations
{
    /// <inheritdoc />
    public partial class VoivodshipTypeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OrdererId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrdererId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrdererId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "OrdererId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Voivodship",
                table: "Address",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrdererId",
                table: "Orders",
                column: "OrdererId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OrdererId",
                table: "Orders",
                column: "OrdererId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OrdererId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrdererId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "OrdererId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "OrdererId1",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Voivodship",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrdererId1",
                table: "Orders",
                column: "OrdererId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OrdererId1",
                table: "Orders",
                column: "OrdererId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
