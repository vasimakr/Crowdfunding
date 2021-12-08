using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding.Migrations
{
    public partial class statusupdatelist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusUpdate",
                table: "Projects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusUpdate",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
