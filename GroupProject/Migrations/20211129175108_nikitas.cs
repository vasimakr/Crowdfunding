using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding.Migrations
{
    public partial class nikitas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundingPackage_Backers_BackerId",
                table: "FundingPackage");

            migrationBuilder.DropIndex(
                name: "IX_FundingPackage_BackerId",
                table: "FundingPackage");

            migrationBuilder.DropColumn(
                name: "BackerId",
                table: "FundingPackage");

            migrationBuilder.CreateTable(
                name: "BackerPackage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackerId = table.Column<int>(type: "int", nullable: true),
                    FundingPackageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackerPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackerPackage_Backers_BackerId",
                        column: x => x.BackerId,
                        principalTable: "Backers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BackerPackage_FundingPackage_FundingPackageId",
                        column: x => x.FundingPackageId,
                        principalTable: "FundingPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackerPackage_BackerId",
                table: "BackerPackage",
                column: "BackerId");

            migrationBuilder.CreateIndex(
                name: "IX_BackerPackage_FundingPackageId",
                table: "BackerPackage",
                column: "FundingPackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackerPackage");

            migrationBuilder.AddColumn<int>(
                name: "BackerId",
                table: "FundingPackage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FundingPackage_BackerId",
                table: "FundingPackage",
                column: "BackerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundingPackage_Backers_BackerId",
                table: "FundingPackage",
                column: "BackerId",
                principalTable: "Backers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
