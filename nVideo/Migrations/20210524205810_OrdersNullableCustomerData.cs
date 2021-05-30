using Microsoft.EntityFrameworkCore.Migrations;

namespace nVideo.Migrations
{
    public partial class OrdersNullableCustomerData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Profiles_CustomerDataId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerDataId",
                table: "Orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Profiles_CustomerDataId",
                table: "Orders",
                column: "CustomerDataId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Profiles_CustomerDataId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerDataId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Profiles_CustomerDataId",
                table: "Orders",
                column: "CustomerDataId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
