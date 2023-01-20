using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp1.Server.Data.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                schema: "public",
                table: "user",
                type: "character varying",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                schema: "public",
                table: "user");
        }
    }
}
