using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace nVideo.Migrations
{
    public partial class CityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopCartId",
                table: "ShopCartItems");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ShopCartItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ShopCartItems");

            migrationBuilder.AddColumn<string>(
                name: "ShopCartId",
                table: "ShopCartItems",
                type: "text",
                nullable: true);
        }
    }
}
