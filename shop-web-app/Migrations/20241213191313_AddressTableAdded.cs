using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_web_app.Migrations
{
    /// <inheritdoc />
    public partial class AddressTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Address_BillingAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Address_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_BillingAddressId",
                table: "Orders",
                column: "BillingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_BillingAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Address_BillingAddressId",
                table: "Orders",
                column: "BillingAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Address_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
