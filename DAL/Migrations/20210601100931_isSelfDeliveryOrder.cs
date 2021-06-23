using Microsoft.EntityFrameworkCore.Migrations;

namespace nVideo.Migrations
{
    public partial class isSelfDeliveryOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelfDelivery",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelfDelivery",
                table: "Orders");
        }
    }
}
