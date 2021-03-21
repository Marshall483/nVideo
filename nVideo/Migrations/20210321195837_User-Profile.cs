using Microsoft.EntityFrameworkCore.Migrations;

namespace nVideo.Migrations
{
    public partial class UserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Age = table.Column<short>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    City = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AspNetUsers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_AspNetUsers",
                        column: x => x.AspNetUsers,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AspNetUsers",
                table: "Profiles",
                column: "AspNetUsers",
                unique: true,
                filter: "[AspNetUsers] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "AspNetUsers");
        }
    }
}
