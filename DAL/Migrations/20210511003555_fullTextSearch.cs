using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

namespace nVideo.Migrations
{
    public partial class fullTextSearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "Entities",
                type: "tsvector",
                nullable: true)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "Name", "Long_Desc" });

            migrationBuilder.CreateIndex(
                name: "IX_Entities_SearchVector",
                table: "Entities",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Entities_SearchVector",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "Entities");
        }
    }
}
