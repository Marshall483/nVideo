using Microsoft.EntityFrameworkCore.Migrations;

namespace nVideo.Migrations
{
    public partial class FixPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Attribute_Catalog_Entity_EntityId",
                table: "Catalog_Attribute");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Entity_Catalog_Category_CategoryId",
                table: "Catalog_Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Value_Catalog_Attribute_Catalog_Attribute",
                table: "Catalog_Value");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Catalog_Entity_EntityId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId1",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalog_Value",
                table: "Catalog_Value");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalog_Entity",
                table: "Catalog_Entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalog_Category",
                table: "Catalog_Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalog_Attribute",
                table: "Catalog_Attribute");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "Catalog_Value",
                newName: "Values");

            migrationBuilder.RenameTable(
                name: "Catalog_Entity",
                newName: "Entities");

            migrationBuilder.RenameTable(
                name: "Catalog_Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Catalog_Attribute",
                newName: "Attributes");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId1",
                table: "Comments",
                newName: "IX_Comments_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_EntityId",
                table: "Comments",
                newName: "IX_Comments_EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Value_Catalog_Attribute",
                table: "Values",
                newName: "IX_Values_Catalog_Attribute");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Entity_CategoryId",
                table: "Entities",
                newName: "IX_Entities_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Attribute_EntityId",
                table: "Attributes",
                newName: "IX_Attributes_EntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Values",
                table: "Values",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entities",
                table: "Entities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patch = table.Column<string>(nullable: true),
                    Catalog_EntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Entities_Catalog_EntityId",
                        column: x => x.Catalog_EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_Catalog_EntityId",
                table: "Pictures",
                column: "Catalog_EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Entities_EntityId",
                table: "Attributes",
                column: "EntityId",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Entities_EntityId",
                table: "Comments",
                column: "EntityId",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId1",
                table: "Comments",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_Categories_CategoryId",
                table: "Entities",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Values_Attributes_Catalog_Attribute",
                table: "Values",
                column: "Catalog_Attribute",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Entities_EntityId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Entities_EntityId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Entities_Categories_CategoryId",
                table: "Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Values_Attributes_Catalog_Attribute",
                table: "Values");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Values",
                table: "Values");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entities",
                table: "Entities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes");

            migrationBuilder.RenameTable(
                name: "Values",
                newName: "Catalog_Value");

            migrationBuilder.RenameTable(
                name: "Entities",
                newName: "Catalog_Entity");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Catalog_Category");

            migrationBuilder.RenameTable(
                name: "Attributes",
                newName: "Catalog_Attribute");

            migrationBuilder.RenameIndex(
                name: "IX_Values_Catalog_Attribute",
                table: "Catalog_Value",
                newName: "IX_Catalog_Value_Catalog_Attribute");

            migrationBuilder.RenameIndex(
                name: "IX_Entities_CategoryId",
                table: "Catalog_Entity",
                newName: "IX_Catalog_Entity_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId1",
                table: "Comment",
                newName: "IX_Comment_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_EntityId",
                table: "Comment",
                newName: "IX_Comment_EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Attributes_EntityId",
                table: "Catalog_Attribute",
                newName: "IX_Catalog_Attribute_EntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalog_Value",
                table: "Catalog_Value",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalog_Entity",
                table: "Catalog_Entity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalog_Category",
                table: "Catalog_Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalog_Attribute",
                table: "Catalog_Attribute",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Catalog_EntityId = table.Column<int>(type: "int", nullable: true),
                    Patch = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Catalog_Entity_Catalog_EntityId",
                        column: x => x.Catalog_EntityId,
                        principalTable: "Catalog_Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_Catalog_EntityId",
                table: "Image",
                column: "Catalog_EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Attribute_Catalog_Entity_EntityId",
                table: "Catalog_Attribute",
                column: "EntityId",
                principalTable: "Catalog_Entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Entity_Catalog_Category_CategoryId",
                table: "Catalog_Entity",
                column: "CategoryId",
                principalTable: "Catalog_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Value_Catalog_Attribute_Catalog_Attribute",
                table: "Catalog_Value",
                column: "Catalog_Attribute",
                principalTable: "Catalog_Attribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Catalog_Entity_EntityId",
                table: "Comment",
                column: "EntityId",
                principalTable: "Catalog_Entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId1",
                table: "Comment",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
