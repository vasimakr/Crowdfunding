using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding.Migrations
{
    public partial class statusupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusUpdate",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusUpdate",
                table: "Projects");
        }
    }
}
