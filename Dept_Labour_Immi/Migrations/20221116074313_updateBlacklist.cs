using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dept_Labour_Immi.Migrations
{
    public partial class updateBlacklist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "blacklists");

            migrationBuilder.RenameColumn(
                name: "penalty",
                table: "blacklists",
                newName: "penaltyType");

            migrationBuilder.AddColumn<int>(
                name: "ThaiCompanyID",
                table: "blacklists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_blacklists_ThaiCompanyID",
                table: "blacklists",
                column: "ThaiCompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_blacklists_thaiCompanies_ThaiCompanyID",
                table: "blacklists",
                column: "ThaiCompanyID",
                principalTable: "thaiCompanies",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blacklists_thaiCompanies_ThaiCompanyID",
                table: "blacklists");

            migrationBuilder.DropIndex(
                name: "IX_blacklists_ThaiCompanyID",
                table: "blacklists");

            migrationBuilder.DropColumn(
                name: "ThaiCompanyID",
                table: "blacklists");

            migrationBuilder.RenameColumn(
                name: "penaltyType",
                table: "blacklists",
                newName: "penalty");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "blacklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
