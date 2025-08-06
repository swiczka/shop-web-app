using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_web_app.Migrations
{
    /// <inheritdoc />
    public partial class ModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasModel",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModelUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasModel",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModelUrl",
                table: "Products");
        }
    }
}
