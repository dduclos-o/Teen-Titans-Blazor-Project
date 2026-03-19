using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeenTitansRP.Migrations
{
    public partial class Changesu7777 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Teams");

            migrationBuilder.AddColumn<bool>(
                name: "isGood",
                table: "Teams",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isGood",
                table: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
