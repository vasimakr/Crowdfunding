using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding.Migrations
{
    public partial class somechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackerPackage_Backers_BackerId",
                table: "BackerPackage");

            migrationBuilder.DropForeignKey(
                name: "FK_BackerPackage_FundingPackage_FundingPackageId",
                table: "BackerPackage");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingPackage_Projects_ProjectId",
                table: "FundingPackage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FundingPackage",
                table: "FundingPackage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BackerPackage",
                table: "BackerPackage");

            migrationBuilder.RenameTable(
                name: "FundingPackage",
                newName: "FundingPackages");

            migrationBuilder.RenameTable(
                name: "BackerPackage",
                newName: "BackerPackages");

            migrationBuilder.RenameIndex(
                name: "IX_FundingPackage_ProjectId",
                table: "FundingPackages",
                newName: "IX_FundingPackages_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_BackerPackage_FundingPackageId",
                table: "BackerPackages",
                newName: "IX_BackerPackages_FundingPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_BackerPackage_BackerId",
                table: "BackerPackages",
                newName: "IX_BackerPackages_BackerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FundingPackages",
                table: "FundingPackages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BackerPackages",
                table: "BackerPackages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BackerPackages_Backers_BackerId",
                table: "BackerPackages",
                column: "BackerId",
                principalTable: "Backers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BackerPackages_FundingPackages_FundingPackageId",
                table: "BackerPackages",
                column: "FundingPackageId",
                principalTable: "FundingPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingPackages_Projects_ProjectId",
                table: "FundingPackages",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackerPackages_Backers_BackerId",
                table: "BackerPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_BackerPackages_FundingPackages_FundingPackageId",
                table: "BackerPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingPackages_Projects_ProjectId",
                table: "FundingPackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FundingPackages",
                table: "FundingPackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BackerPackages",
                table: "BackerPackages");

            migrationBuilder.RenameTable(
                name: "FundingPackages",
                newName: "FundingPackage");

            migrationBuilder.RenameTable(
                name: "BackerPackages",
                newName: "BackerPackage");

            migrationBuilder.RenameIndex(
                name: "IX_FundingPackages_ProjectId",
                table: "FundingPackage",
                newName: "IX_FundingPackage_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_BackerPackages_FundingPackageId",
                table: "BackerPackage",
                newName: "IX_BackerPackage_FundingPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_BackerPackages_BackerId",
                table: "BackerPackage",
                newName: "IX_BackerPackage_BackerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FundingPackage",
                table: "FundingPackage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BackerPackage",
                table: "BackerPackage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BackerPackage_Backers_BackerId",
                table: "BackerPackage",
                column: "BackerId",
                principalTable: "Backers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BackerPackage_FundingPackage_FundingPackageId",
                table: "BackerPackage",
                column: "FundingPackageId",
                principalTable: "FundingPackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingPackage_Projects_ProjectId",
                table: "FundingPackage",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
