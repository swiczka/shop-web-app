using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_web_app.Migrations
{
    /// <inheritdoc />
    public partial class changedSizeQuantNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternationalSizeQuantities_ProductVariants_VariantId",
                table: "InternationalSizeQuantities");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoeSizeQuantities_ProductVariants_VariantId",
                table: "ShoeSizeQuantities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoeSizeQuantities",
                table: "ShoeSizeQuantities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InternationalSizeQuantities",
                table: "InternationalSizeQuantities");

            migrationBuilder.RenameTable(
                name: "ShoeSizeQuantities",
                newName: "ShoeSizeQuantity");

            migrationBuilder.RenameTable(
                name: "InternationalSizeQuantities",
                newName: "InternationalSizeQuantity");

            migrationBuilder.RenameIndex(
                name: "IX_ShoeSizeQuantities_VariantId",
                table: "ShoeSizeQuantity",
                newName: "IX_ShoeSizeQuantity_VariantId");

            migrationBuilder.RenameIndex(
                name: "IX_InternationalSizeQuantities_VariantId",
                table: "InternationalSizeQuantity",
                newName: "IX_InternationalSizeQuantity_VariantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoeSizeQuantity",
                table: "ShoeSizeQuantity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InternationalSizeQuantity",
                table: "InternationalSizeQuantity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InternationalSizeQuantity_ProductVariants_VariantId",
                table: "InternationalSizeQuantity",
                column: "VariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoeSizeQuantity_ProductVariants_VariantId",
                table: "ShoeSizeQuantity",
                column: "VariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternationalSizeQuantity_ProductVariants_VariantId",
                table: "InternationalSizeQuantity");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoeSizeQuantity_ProductVariants_VariantId",
                table: "ShoeSizeQuantity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoeSizeQuantity",
                table: "ShoeSizeQuantity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InternationalSizeQuantity",
                table: "InternationalSizeQuantity");

            migrationBuilder.RenameTable(
                name: "ShoeSizeQuantity",
                newName: "ShoeSizeQuantities");

            migrationBuilder.RenameTable(
                name: "InternationalSizeQuantity",
                newName: "InternationalSizeQuantities");

            migrationBuilder.RenameIndex(
                name: "IX_ShoeSizeQuantity_VariantId",
                table: "ShoeSizeQuantities",
                newName: "IX_ShoeSizeQuantities_VariantId");

            migrationBuilder.RenameIndex(
                name: "IX_InternationalSizeQuantity_VariantId",
                table: "InternationalSizeQuantities",
                newName: "IX_InternationalSizeQuantities_VariantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoeSizeQuantities",
                table: "ShoeSizeQuantities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InternationalSizeQuantities",
                table: "InternationalSizeQuantities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InternationalSizeQuantities_ProductVariants_VariantId",
                table: "InternationalSizeQuantities",
                column: "VariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoeSizeQuantities_ProductVariants_VariantId",
                table: "ShoeSizeQuantities",
                column: "VariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
