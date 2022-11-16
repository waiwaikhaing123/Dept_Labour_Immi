using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dept_Labour_Immi.Migrations
{
    public partial class DOE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DOEs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOENo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOEs", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_opearationOne_DOEID",
                table: "opearationOne",
                column: "DOEID");

            migrationBuilder.AddForeignKey(
                name: "FK_opearationOne_DOEs_DOEID",
                table: "opearationOne",
                column: "DOEID",
                principalTable: "DOEs",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_opearationOne_DOEs_DOEID",
                table: "opearationOne");

            migrationBuilder.DropTable(
                name: "DOEs");

            migrationBuilder.DropIndex(
                name: "IX_opearationOne_DOEID",
                table: "opearationOne");
        }
    }
}
