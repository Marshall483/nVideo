using Microsoft.EntityFrameworkCore.Migrations;

namespace nVideo.Migrations
{
    public partial class AddRaitingCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Raiting",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Raiting",
                table: "Comments");
        }
    }
}
