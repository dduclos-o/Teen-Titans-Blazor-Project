using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeenTitansRP.Migrations
{
    public partial class Changes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PowerLevel",
                table: "Powers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PowerLevel",
                table: "Powers",
                type: "float",
                nullable: true);
        }
    }
}
