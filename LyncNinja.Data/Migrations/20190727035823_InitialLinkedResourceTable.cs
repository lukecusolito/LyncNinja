using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LyncNinja.Data.Migrations
{
    public partial class InitialLinkedResourceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkedResources",
                columns: table => new
                {
                    UID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedResources", x => x.UID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkedResources_Url",
                table: "LinkedResources",
                column: "Url",
                unique: true,
                filter: "[Url] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkedResources");
        }
    }
}
