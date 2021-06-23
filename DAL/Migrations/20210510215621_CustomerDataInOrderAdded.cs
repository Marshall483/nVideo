using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace nVideo.Migrations
{
    public partial class CustomerDataInOrderAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Oreder_Time",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ShopCartItems",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CustomerDataId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Orders",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItems_OrderId",
                table: "ShopCartItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerDataId",
                table: "Orders",
                column: "CustomerDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Profiles_CustomerDataId",
                table: "Orders",
                column: "CustomerDataId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Orders_OrderId",
                table: "ShopCartItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Profiles_CustomerDataId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Orders_OrderId",
                table: "ShopCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShopCartItems_OrderId",
                table: "ShopCartItems");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerDataId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ShopCartItems");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerDataId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "Oreder_Time",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
