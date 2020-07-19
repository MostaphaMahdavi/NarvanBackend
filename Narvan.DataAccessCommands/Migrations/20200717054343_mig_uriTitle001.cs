using Microsoft.EntityFrameworkCore.Migrations;

namespace Narvan.DataAccessCommands.Migrations
{
    public partial class mig_uriTitle001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlTitle",
                table: "ProductCategory",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlTitle",
                table: "ProductCategory");
        }
    }
}
